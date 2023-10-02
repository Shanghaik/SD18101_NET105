﻿using AppsData.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AppProgram_MVC.Controllers
{
    public class SinhvienController : Controller
    {
        public SinhvienController()
        {

        }
        // GET: SinhvienController
        public async Task<ActionResult> Index()
        {
            // Để call được API thì chúng ta cần lấy được URL request
            string requestURL = "https://localhost:44370/api/Sinhviens";
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(requestURL); // rấy response
            // Đọc từ response chuỗi Json là kết quả của phép trả về
            string apiData = await response.Content.ReadAsStringAsync();
            // Có data rồi thì ta sẽ convert về dữ liệu mình cần để đưa sang view
            var sinhviens = JsonConvert.DeserializeObject<List<Sinhvien>>(apiData);
            return View(sinhviens);
        }
        /*
         * Bất đồng bộ khác với đa luồng
         * Bất đồng bộ là một cơ chế trong lập trình cho phép các hành động 
         * trong chương trình thực thi đan xen lẫn nhau mà không cần chờ đợi hay 
         * thực thi một luồng cho đến khi nhận giá trị. Có nhiều cách để xử lý bất
         * đồng bộ nhưng quá trình này thường được diễn ra như sau:
         * Khi có 1 request (luồng chính), luồng này có thể bao gồm nhiều luồng con
         * thì để sinh ra một response cuối cùng ta cần thực thi các luồng con khi
         * đó việc xử lý này được chi nhỏ ra và thực hiện bất đồng bộ để gia tăng 
         * hiệu suất của chương trình và tận dụng tối đa tài nguyên của hệ thống
         * số lượng luồng chạy tối đa <= số thread mà hệ thống có thể cung cấp
         * Ví dụ: Công việc: Nhậu (Thịt gà, mua bia, nấu cơm, Alo nhau, giải chiếu,..)
         * có các luồng là ông Khánh, ông Dũng, ông Tiến cùng làm những việc này
         * Thịt gà thì cần đun nước => ông Khánh đi đun nước, nhưng trong khi nước
         * được đun, thì không chờ mà ông này lại đi rửa rau, khi ông khánh chưa rửa
         * rau xong thì nước đã sôi, ông Dũng đi bắt gà còn ông Tiến đi bắc nước ra 
         * để thịt,,,..... các công việc sẽ được các thread xử lý đan xen lần nhau mà
         * không đợi kết quả hay không định danh cho bất kì thread nào làm công việc
         * cụ thể nào => Thread Pool => Thread pool sẽ cơ chế hàng đợi
         */

        // GET: SinhvienController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SinhvienController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SinhvienController/Create
        [HttpPost]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SinhvienController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SinhvienController/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SinhvienController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }
        
    }
}
