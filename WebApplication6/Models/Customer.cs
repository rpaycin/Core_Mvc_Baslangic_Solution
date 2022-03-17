    using System.ComponentModel.DataAnnotations;

namespace App.Web.Models
{
    public class Customer
    {
        //[Required(ErrorMessage ="İsim gerekli")] => bu dataannotation. biz fluent validation ile yapcaz
        public string Name { get; set; }
    }
}
