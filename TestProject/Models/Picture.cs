using System.ComponentModel.DataAnnotations;

namespace TestProject.Models
{
    public class Picture
    {

        #region Declaration


        [Key]  // JEMO : let the EF know to handle the Picturerating.ID as a Primairy Key. 
        // this is not mandatory as the EF seems to automatically understand a Primairy key field when using {ModelName}Id and even ID, but i want to make sure it makes no mistake
        public int ID { get; set; }

        [MaxLength(100)] // JEMO : Determine the maxium allowed size a Picture.Name can have
        public string Name { get; set; }

        public string Url { get; set; }


        #endregion


    }
}