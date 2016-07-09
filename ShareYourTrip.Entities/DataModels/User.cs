using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShareYourTrip.Entities.DataModels
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
       


        //TODO Set all properties
        //TODO evaluar que va en UserProfile y que en USer

        public virtual UserRole Role { get; set; }

        [ForeignKey("UserProfile")]
        public int UserProfileId { get; set; }
        public virtual UserProfile UserProfile { get; set; }

    }

   
}
