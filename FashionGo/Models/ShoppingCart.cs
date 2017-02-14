namespace FashionGo.Models
{
    using FashionGo.Models.Entities;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    public class ShoppingCart
    {

        
        // Chứa các mặt hàng đã chọn
        public List<Product> Items = new List<Product>();

        public int Count { get; set; }

        public double Total  { get; set; }

        public Coupon Coupon { get; set; }

        public Transport Transport { get; set; }

        

        // Lấy giỏ hàng từ Session
        public static ShoppingCart Cart
        {
            get
            {
                var cart = HttpContext.Current.Session["Cart"] as ShoppingCart;
                // Nếu chưa có giỏ hàng trong session -> tạo mới và lưu vào session
                if (cart == null)
                {
                    cart = new ShoppingCart();
                    cart.Count = 0;
                    cart.Total = 0;
                    HttpContext.Current.Session["Cart"] = cart;
                }
                return cart;
            }
        }

        public string CouponCode {
            get {
                if (Coupon != null)
                {
                    return Coupon.Code;
                }
                return "";
            }
        }

        public double Discount
        {
            get
            {
                var db = new ApplicationDbContext();
                if (Coupon == null)
                {
                    return 0;
                }

                switch (Coupon.DiscountFor)
                {
                    case DiscountObject.Product:
                        if (Coupon.DiscountForId.HasValue)
                        {
                            var product = db.Products.Find(Coupon.DiscountForId);
                            if (Items.Contains(product))
                            {
                                return (double)product.PriceAfter * Coupon.Discount / 100;
                            }
                        }
                        else
                        {
                            return 0;
                        }
                        break;
                    case DiscountObject.Order:
                        return (double)Total * Coupon.Discount / 100;
                    case DiscountObject.Transport:
                        return (double)Transport.Cost * Coupon.Discount / 100;

                }
                db.Dispose();
                return 0;
            }
        }

        public string discountDescription
        {
            get
            {
                if (Coupon == null)
                {
                    return "";
                }

                return "<br><small>(" + Coupon.Name + ")</small";
            }
        }

        public double OrderTotal
        {
            get
            {
                return Total + TransportCost - Discount;
            }
        }


        public double TransportCost 
        {
            get
            {
                var cost = Transport == null ? 0 : Transport.Cost.Value; 
                //Nếu số tiền lớn hơn 300k hoặc số lượng mua từ 3 sản phẩm trở lên thì miễn phí vận chuyển
                if (Total > 300000 || Count > 2)
                {
                    cost = cost - 15000;
                }

                return cost < 0 ? 0 : cost;
            }
        }


        public void Add(int id, int soluong)
        {
            var db = new ApplicationDbContext();
            Product item = null;
            try // tìm thấy trong giỏ -> tăng số lượng lên 1
            {
                item = Items.Single(i => i.Id == id);
                item.Amount = item.Amount + soluong;
            }
            catch // chưa có trong giỏ -> truy vấn CSDL và bỏ vào giỏ
            {
                
                item = db.Products.Find(id);
                item.Amount = soluong;

                Items.Add(item);
            }
            Total += item.PriceAfter.Value * soluong;
            Count += soluong;
            db.Dispose();
        }

        public void Remove(int id)
        {
            var item = Items.Single(i => i.Id == id);
            Total -= item.PriceAfter.Value*item.Amount.Value;
            Count -= item.Amount.Value;
            Items.Remove(item);
        }

        public void Update(int id, int newQuantity)
        {
            var item = Items.Single(i => i.Id == id);
            Total += item.PriceAfter.Value * (newQuantity - item.Amount.Value);
            Count += newQuantity - item.Amount.Value;
            item.Amount = newQuantity;
        }

        public void UpdateCoupon(Coupon coupon)
        {
            Coupon = coupon;
        }

        public void UpdateTransport(Transport transport)
        {
            Transport = transport;
        }

        public int getQuantity(int id)
        {
            var item = Items.Single(i => i.Id == id);
            return item.Amount.Value;
        }

        public void Clear()
        {
            Count = 0;
            Total = 0;
            Items.Clear();
        }

    }
}
