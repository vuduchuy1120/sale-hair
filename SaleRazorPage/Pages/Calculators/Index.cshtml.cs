using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SaleRazorPage.Model;

namespace SaleRazorPage.Pages.Calculators
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _db;

        public IndexModel(AppDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public bool isWholeSale { get; set; } = false;

        [BindProperty]
        public List<int> QuantityBundle { get; set; } = new List<int>();

        [BindProperty]
        public List<int> QuantityClosure { get; set; } = new List<int>();

        [BindProperty]
        public List<double> QuantityPerBundle { get; set; } = new List<double>();

        [BindProperty]
        public List<Guid> SetHairRequestId { get; set; } = new List<Guid>();

        [BindProperty]
        public List<Guid> LengthBundleId { get; set; } = new List<Guid>();

        [BindProperty]
        public List<Guid> LengthClosureId { get; set; } = new List<Guid>();

        [BindProperty]
        public List<Guid> ColorId { get; set; } = new List<Guid>();

        [BindProperty]
        public List<Guid> ThicknessId { get; set; } = new List<Guid>();

        [BindProperty]
        public List<Guid> GridSizeId { get; set; } = new List<Guid>();

        public decimal TotalHairPrice { get; set; } = 0;
        public decimal TotalClosurePrice { get; set; } = 0;
        public decimal TotalPrice { get; set; } = 0;

        public IList<SetHairRequest> SetHairRequests { get; set; } = default!;
        public IList<Length> Lengths { get; set; } = default!;
        public IList<Color> Colors { get; set; } = default!;
        public IList<Thickness> Thicknesses { get; set; } = default!;
        public IList<GridSize> GridSizes { get; set; } = default!;

        public async Task OnGetAsync()
        {
            // Fetch SetHairRequests
            SetHairRequests = await _db.HairRequests.ToListAsync() ?? new List<SetHairRequest>();
            ViewData["SetHairRequestId"] = new SelectList(SetHairRequests, "Id", "Name");

            // Fetch Lengths
            Lengths = await _db.Lengths.ToListAsync() ?? new List<Length>();
            ViewData["LengthId"] = new SelectList(Lengths, "Id", "Inch");

            // Fetch Colors
            Colors = await _db.Colors.OrderBy(c => c.Name).ToListAsync() ?? new List<Color>();
            ViewData["ColorId"] = new SelectList(Colors, "Id", "Name");

            // Fetch Thicknesses
            Thicknesses = await _db.Thickness.ToListAsync() ?? new List<Thickness>();
            ViewData["ThicknessId"] = new SelectList(Thicknesses, "Id", "Name");

            // Fetch GridSizes
            GridSizes = await _db.GridSizes.ToListAsync() ?? new List<GridSize>();
            ViewData["GridSizeId"] = new SelectList(GridSizes, "Id", "Size");
        }

        public async Task<IActionResult> OnPostAsync(
            List<Guid> SetHairRequestId,
            List<int> QuantityBundle,
            List<double> QuantityPerBundle,
            List<Guid> LengthBundleId,
            List<Guid> ThicknessId
        )
        {
            int totalQuantity = 0;
            decimal totalHairPrice = 0;
            decimal totalClosurePrice = 0;
            List<object> results = new List<object>();

            for (int i = 0; i < SetHairRequestId.Count; i++)
            {
                totalQuantity += QuantityBundle[i] * (int)QuantityPerBundle[i];
            }
            if (totalQuantity >= 2000)
            {
                isWholeSale = true;
            }
            else
            {
                isWholeSale = false;
            }

            // Lặp qua tất cả các form và tính tổng giá
            for (int i = 0; i < SetHairRequestId.Count; i++)
            {
                var priceRowBundle = await _db.LengThicknessPrice
                   .Where(p => p.LengthId == LengthBundleId[i] && p.ThicknessId == ThicknessId[i] && p.IsWholeSale == isWholeSale)
                   .FirstOrDefaultAsync();

                if (priceRowBundle != null)
                {
                    decimal price = Decimal.Multiply(priceRowBundle.Price * QuantityBundle[i], (decimal)QuantityPerBundle[i]) / 100;
                    totalHairPrice += price;

                    // Thu thập thông tin từng form
                    var setHairRequest = await _db.HairRequests.FindAsync(SetHairRequestId[i]);
                    var length = await _db.Lengths.FindAsync(LengthBundleId[i]);
                    var thickness = await _db.Thickness.FindAsync(ThicknessId[i]);

                    results.Add(new
                    {
                        SetHairRequestName = setHairRequest.Name,
                        QuantityBundle = QuantityBundle[i],
                        QuantityPerBundle = QuantityPerBundle[i],
                        LengthBundle = length.Inch,
                        Thickness = thickness.Name,
                        Price = price
                    });
                }
            }

            // Tính tổng giá cuối cùng
            decimal totalPrice = totalHairPrice + totalClosurePrice;

            // Trả về JSON response bao gồm thông tin từng form
            return new JsonResult(new
            {
                success = true,
                totalHairPrice = totalHairPrice,
                totalClosurePrice = totalClosurePrice,
                totalPrice = totalPrice,
                results = results
            });
        }

        public async Task<IActionResult> OnPostCalculateClosureAsync(
            List<Guid> LengthClosureId,
            List<int> QuantityClosure,
            List<double> QuantityPerBundleClosure,
            List<Guid> GridSizeId
        )
        {
            decimal totalClosurePrice = 0;
            List<object> closureResults = new List<object>();

            for (int i = 0; i < LengthClosureId.Count; i++)
            {
                // Giả sử bạn có bảng giá cho Closure tương tự như bó tóc
                var priceRowClosure = await _db.LengthGridSizePrice
                    .Where(p => p.LengthId == LengthClosureId[i] && p.GridSizeId == GridSizeId[i] && p.IsWholeSale == isWholeSale)
                    .FirstOrDefaultAsync();

                if (priceRowClosure != null)
                {
                    decimal price = priceRowClosure.Price * QuantityClosure[i];
                    totalClosurePrice += price;

                    // Thu thập thông tin từng closure form
                    var length = await _db.Lengths.FindAsync(LengthClosureId[i]);
                    var gridSize = await _db.GridSizes.FindAsync(GridSizeId[i]);

                    closureResults.Add(new
                    {
                        LengthClosure = length.Inch,
                        QuantityClosure = QuantityClosure[i],
                        QuantityPerBundleClosure = QuantityPerBundleClosure[i],
                        GridSize = gridSize.Size,
                        Price = price
                    });
                }
            }

            // Tính tổng giá Closure
            decimal totalPrice = totalClosurePrice;

            // Trả về JSON response bao gồm thông tin từng closure form
            return new JsonResult(new
            {
                success = true,
                totalClosurePrice = totalClosurePrice,
                totalPrice = totalPrice,
                closureResults = closureResults
            });
        }

    }
}
