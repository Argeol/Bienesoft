using System.ComponentModel.DataAnnotations;

namespace bienesoft.Models
{
    public class LearnerModel
    {
        [Key]public int  Id_Learner { get; set; }

        public string Learner_Name { get; set; }

        public string Learner_Phone { get; set; }

        public string Learner_Type { get; set; }

        public int Session_Count { get; set; }

        public int JWT_Token { get; set; }
    }

}
