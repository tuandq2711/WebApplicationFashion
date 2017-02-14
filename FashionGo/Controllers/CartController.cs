using System.Linq;
using System.Web.Mvc;
using FashionGo.Models.Entities;
using FashionGo.Models;

namespace FashionGo.Controllers
{
    public class CartController : BaseController
    {
        public ActionResult Index()
        {
            if (ShoppingCart.Cart.Count == 0)
            {
                Warning(string.Format("<b><h5>{0}</h4></b>", "Bạn chưa có sản phẩm nào trong giỏ hàng, Vui lòng chọn sản phẩm trước khi thanh toán."), true);
                return RedirectToAction("Index", "Home");
            }

            var cart = ShoppingCart.Cart;
            return View(cart.Items);
            
        }
        public ActionResult OrderDetail()
        { 
            var cart = ShoppingCart.Cart;
            return PartialView("Partials/_OrderDetail", cart.Items);
        }
        

        public ActionResult _PartialCart()
        {
            var cart = ShoppingCart.Cart;
            return PartialView(cart.Items);
        }

        public ActionResult Add(int id, int quatity)
        {
            var cart = ShoppingCart.Cart;
            cart.Add(id, quatity);

            var info = new { Count = cart.Count, Total = cart.Total };
            return Json(info, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Remove(int id)
        {
            var cart = ShoppingCart.Cart;
            cart.Remove(id);

            var info = new { Count = cart.Count, Total = cart.Total };
            return Json(info, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Update(int id, int quantity)
        {
            var cart = ShoppingCart.Cart;
            cart.Update(id, quantity);

            var p = cart.Items.Single(i => i.Id == id);
            var info = new
            {
                Count = cart.Count,
                Total = cart.Total,
                quantity=quantity,
                Amount = p.PriceAfter.Value * p.Amount
            };
            return Json(info, JsonRequestBehavior.AllowGet);
        }


        public ActionResult Clear()
        {
            
            var cart = ShoppingCart.Cart;
            cart.Clear();
            return RedirectToAction("Index");
        }

        public ActionResult _MiniCart()
        {
            return PartialView();
        }
    }
}