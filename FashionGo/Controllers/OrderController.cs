using FashionGo.Models.Entities;
using FashionGo.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Commons.Libs;

namespace FashionGo.Controllers
{
    public class OrderController : BaseController
    {

        public ShoppingCart cart = ShoppingCart.Cart;

        [HttpGet]
        public ActionResult Checkout()
        {
            if (cart.Count == 0)
            {
                Warning(string.Format("<b><h5>{0}</h4></b>", "Bạn chưa có sản phẩm nào trong giỏ hàng, Vui lòng chọn sản phẩm trước khi thanh toán."), true);
                return RedirectToAction("Index", "Home");
            }

            ViewBag.ProvinceId = new SelectList(db.Provinces.Select(x => new { ProvinceId = x.ProvinceId, NameFull = x.Type + " " + x.Name }), "ProvinceId", "NameFull");
            ViewBag.DistrictId = new SelectList(db.Districts.Where(d => d.ProvinceId == "-1").Select(x => new { DistrictId = x.DistrictId, NameFull = x.Type + " " + x.Name }), "DistrictId", "NameFull");

            var model = new Order();

            if (ModelState.IsValid && Request.IsAuthenticated)
            {
                model.UserId = User.Identity.GetUserId();
                var user = db.Users.Find(User.Identity.GetUserId());
                model.ReceiveName = user.FullName;
                model.ReceivePhone = user.PhoneNumber;
                model.ReceiveAddress = user.Address;

                ViewBag.Email = user.UserName;

                if (user.District != null)//second
                {
                    ViewBag.ProvinceId = new SelectList(db.Provinces.Select(x => new { ProvinceId = x.ProvinceId, NameFull = x.Type + " " +  x.Name }), "ProvinceId", "NameFull", user.District.ProvinceId);
                    ViewBag.DistrictId = new SelectList(db.Districts.Where(d => d.ProvinceId == user.District.ProvinceId).Select(x => new { DistrictId = x.DistrictId, NameFull = x.Type + " " + x.Name }), "DistrictId", "NameFull", user.DistrictId);
                }
            }

            return View(model);
        }
        

        [HttpPost]
        public async System.Threading.Tasks.Task<ActionResult> Checkout(Order model, FormCollection form)
        {
            var sms = new SpeedSMSAPI();
            //Validate Cart
            if (cart.Count == 0)
            {
                Warning(string.Format("<h5>{0}</h4>", "Bạn chưa có sản phẩm nào trong giỏ hàng, Vui lòng chọn sản phẩm trước khi thanh toán."), true);
                return RedirectToAction("Index", "Home");
            }
            // Validate Email
            if (! Request.IsAuthenticated && String.IsNullOrEmpty(form["Email"]))
                ModelState.AddModelError("", "-Bạn chưa nhập email nhận đơn hàng!");

            //Check quận huyện
            if (String.IsNullOrEmpty(form["DistrictId"]))
                ModelState.AddModelError("", "-Bạn chưa chọn quận huyện nơi chuyển hàng tới!");

            //Check phuong thuc van chuyen
            if (String.IsNullOrEmpty(form["TransportId"]))
                ModelState.AddModelError("", "-Bạn chưa chọn nhà vận chuyển trước khi đặt hàng!");


            var user = db.Users.Find(model.UserId);
            //Kiểm tra nếu là người dùng mới thì tạo tài khoản
            if (string.IsNullOrEmpty(model.UserId))
            {
                var password = Xstring.GeneratePassword();
                var newUser = new ApplicationUser
                {
                    UserName = form["Email"],
                    Email = form["Email"],
                    PhoneNumber = model.ReceivePhone,
                    PasswordHash = password,
                };

                var UserManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();

                var result = await UserManager.CreateAsync(newUser, password);

                if (result.Succeeded)
                {
                    var SignInManager = HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
                    await SignInManager.SignInAsync(newUser, isPersistent: false, rememberBrowser: false);
                    model.UserId = newUser.Id;

                    //Gửi sms
                    string smsAcc = "FashionGo: Tai khoan quan ly don hang cua ban tren FashionGo la: Email:" + form["Email"] + ", mat khau:" + password;
                    string sent = sms.sendSMS(model.ReceivePhone, smsAcc, 2, "");

                    //Gửi tin nhắn tài khoản cho người dùng.
                    var subject = "Tài khoản quản lý đơn hàng tại ZdealVN.!";
                    var msg = "Xin chào, " + model.ReceiveName;
                    msg += "<br>Tài khoản quản lý đơn hàng của bạn tại <a href='http://FashionGo.vn'>FashionGo.vn</a> là:";
                    msg += "<br>-Tên đăng nhập: " + form["Email"];
                    msg += "<br>-Mật khẩu của bạn: " + password;
                    msg += "<br>Bạn có thể sử dụng tài khoản này đăng nhập trên FashionGo.vn để quản lý đơn hàng và sử dụng các dịch vụ khác do FashionGo cung cấp.!";
                    msg += "<br>Cảm ơn bạn đã quan tâm sử dụng dịch vụ của FashionGo. mọi thắc mắc xin liên hệ hotline: 0901.002.822-0965.002.822.";
                    msg += "<br>FashionGo Hân hạnh được phục vụ bạn.";
                    msg += "<br>Chúc bạn một ngày tốt lành.";
                    msg += "<p></p><p></p>-BQT ZdealVN!.</p>";

                    XMail.Send(newUser.Email, subject, msg);
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", "-" + error);
                    }
                }

                ViewBag.Email = form["Email"];
            }
            else if (user != null)
            {
                //update FullName & Phone
                if (string.IsNullOrEmpty(user.FullName))
                {
                    user.FullName = model.ReceiveName;
                }
                if (string.IsNullOrEmpty(user.PhoneNumber))
                {
                    user.PhoneNumber = model.ReceivePhone;
                }

                if (string.IsNullOrEmpty(user.Address))
                {
                    user.Address = model.ReceiveAddress;
                }

                if (string.IsNullOrEmpty(user.DistrictId))
                {
                    user.DistrictId = cart.Transport.DistrictId;
                }
            }

            //Update order info 
            model.TotalAmount = cart.Total;
            model.TotalOrder = cart.OrderTotal;
            if (cart.Transport != null) { model.TransportId = cart.Transport.Id; }
            model.Coupon = cart.CouponCode;
            model.Discount = cart.Discount;
            model.OrderDate = DateTime.Now;
            model.StatusId = 1;

            if (ModelState.IsValid)
            {
                db.Orders.Add(model);
                try
                {
                    foreach (var p in cart.Items)
                    {
                        var d = new OrderDetail
                        {
                            OrderId = model.Id,
                            ProductId = p.Id,
                            PriceAfter = p.PriceAfter.Value,
                            Discount = p.Discount.Value,
                            Amount = p.Amount
                        };
                        //ViewBag.ProductDetail = cart.Items;
                        db.OrderDetails.Add(d);
                    }
                    if (db.SaveChanges() > 0)
                    {
                        cart.Clear();
                        Success(string.Format("<b><h5>{0}</h4></b>", "Đặt hàng thành công, chúng tôi sẽ liên hệ lại với bạn để xác nhận đơn hàng trước khi tiến hành giao hàng."), true);

                        //Gửi SMS xác nhận và báo tin cho Sale
                        
                        var customerMsg = "FashionGo: Dat hang thanh cong don hang:#" + model.Id + ", Voi so tien: " + string.Format("{0:0,0}vnđ", model.TotalAmount);
                        var saleSMS = "FashionGo: Don hang moi #" + model.Id + " tu KH: " + model.ReceiveName + " - " + model.ReceivePhone;
                        string response = sms.sendSMS(model.ReceivePhone, customerMsg, 2, "");
                               response = sms.sendSMS("0931325145", saleSMS, 2, "");

                        return RedirectToAction("Detail", new { id = model.Id });
                    }
                    
                }
                catch (Exception ex)
                {
                    Danger(string.Format("-{0}<br>", ex.Message), true);
                    ModelState.AddModelError("", ex.InnerException);
                }
            }

            var provinceId = form["ProvinceId"];
            ViewBag.ProvinceId = new SelectList(db.Provinces.Select(x => new { ProvinceId = x.ProvinceId, NameFull = x.Type + " " + x.Name }), "ProvinceId", "NameFull", provinceId);
            ViewBag.DistrictId = new SelectList(db.Districts.Where(d => d.ProvinceId == provinceId).Select(x => new { DistrictId = x.DistrictId, NameFull = x.Type + " " + x.Name }), "DistrictId", "NameFull", form["DistrictId"].ToString());

            return View(model);
        }



        public ActionResult Detail(int id)
        {
            var order = db.Orders.Find(id);
            ViewBag.Total = order.StatusId;
            return View(order);
        }

        public ActionResult List()
        {
            string currentUserId = User.Identity.GetUserId();
            var orders = db.Orders.Where(o => o.UserId == currentUserId).ToList();
            return View(orders);
        }

        
        public bool UpdateTransport(int transportId)
        {
            var transport = db.Transports.Find(transportId);
            if (transport == null)
            {
                return false;
            }
            
            //Update cart Transport
            cart.UpdateTransport(transport);

            return true;
        }

        
        public bool UpdateCoupon(string code)
        {
            var coupon = db.Coupons.Find(code);
            if (coupon == null)
            {
                return false;
            }
            //Update cart Transport
            cart.UpdateCoupon(coupon);

            return true;
        }

        
        public ActionResult AjaxGetTransport(string districtId)
        {
            var transports = db.Transports.Where(t => t.DistrictId == districtId).ToList();
            if (transports.Count() > 0)
            {
                UpdateTransport(transports.First().Id);
            }
            return PartialView(transports);
        }

        [HttpPost]
        
        public ActionResult AjaxUpdateCoupon(string couponCode)
        {
            var info = new
            {
                Status = 0,
                Msg = "Coupon không tồn tại hoặc đã hết hạn dùng.!"
            };

            if (UpdateCoupon(couponCode))
            {
                info = new
                {
                    Status = 1,
                    Msg = "Update thành công!"
                };
            }

            return Json(info, JsonRequestBehavior.AllowGet);
        }

        
        public ActionResult getOrderInfo()
        {
            var info = new
            {
                TransportCost = cart.TransportCost,
                Discount = cart.Discount,
                DiscountDescription = cart.discountDescription,
                OrderTotal = cart.OrderTotal
            };
            return Json(info, JsonRequestBehavior.AllowGet);
        }
    }
}