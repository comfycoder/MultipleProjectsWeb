using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace MyApp.Contracts
{
    /// <summary>
    /// Customer
    /// </summary>
    [Display(Description = "Customer", Name = "Customer")]
    [JsonObject(Title = "customer")]
    public class CustomerDto
    {
        /// <summary>
        /// ID of the Customer record.
        /// </summary>
        [Display(Description = "ID" , Name = "CustomerId")]
        [JsonProperty(PropertyName = "id")]
        public int CustomerId { get; set; }

        /// <summary>
        /// Title
        /// </summary>
        [Display(Description = "Title")]
        [StringLength(8)]
        public string Title { get; set; }

        /// <summary>
        /// First Name
        /// </summary>
        [Display(Description = "First Name")]
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        /// <summary>
        ///  Last Name
        /// </summary>
        [Display(Description = "Last Name")]
        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        /// <summary>
        /// Email Address
        /// </summary>
        [Display(Description = "Email Adress")]
        [StringLength(50)]
        public string EmailAddress { get; set; }

        /// <summary>
        /// Phone Number
        /// </summary>
        [Display(Description = "Phone Number")]
        [StringLength(25)]
        public string Phone { get; set; }
    }
}
