using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ExampleBinding.Pages
{
    public class EditProductModel : PageModel
    {
        private readonly ProductService _productService; //Создан недостающий класс ProductService
        public EditProductModel(ProductService productService)
        {
            _productService = productService;
        }
        [BindProperty]
        public InputModel Input { get; set; }
            public IActionResult OnGet(int id)
            {
                var product = _productService.GetProduct(id);
                Input = new InputModel
                {
                    Name = product.Name,
                    Price = product.SellPrice,
                };
                return Page();
            }

        public IActionResult OnPost(int id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _productService.UpdateProduct(id, Input.Name, Input.Price);
            return RedirectToPage("Index");
        }
        public class InputModel
        {
            [Required]
            public string Name { get; set; }
            [Range(0, int.MaxValue)]
            public decimal Price { get; set; }
        }
    }
}