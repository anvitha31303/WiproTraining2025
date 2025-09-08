using Microsoft.AspNetCore.Mvc;

namespace razor_recap_day_25.Models
{
    public class Customer
    {
        [BindProperty]
        public string Name { get; set; }

        [BindProperty]
        public string Email { get; set; }

        public string Message { get; set; }

        public void OnPost()
        {
            Message = $"{Name}, information will be sent to {Email}";
        }

    }
}
