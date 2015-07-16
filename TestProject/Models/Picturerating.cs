using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestProject.Models
{
    public class Picturerating
    {

        #region Declaration


        [Key] // JEMO : let the EF know to handle the Picturerating.ID as a Primairy Key. 
        // this is not mandatory as the EF seems to automatically understand a Primairy key field when using {ModelName}Id or even ID, but i want to make sure it makes no mistake
        public int ID { get; set; }

        [ForeignKey("Picture")] // JEMO : let the EF know to handle the Picturerating.PictureID as a Foreign Key by adding the [ForeignKey] Attribute. 
        // By specifying the Model to which the Foreign key belongs the EF can map the relations between our current model and our Foreign Model.
        public int? PictureID { get; set; }
        public virtual Picture Picture { get; set; } // JEMO : add a virtual reference to the Picture entity who matches the PictureID in order to access it from within the Picturerating model


        [Range(1, 10, ErrorMessage = "Value for {0} must be between {1} and {2}.")] // JEMO : since my picture Rating may only be in a Range of 1 to 10, i can specify this as a required attribute
        // the ErrorMessage i included can be used in my views to generate the message when the user input does not match any option within the allowed range. i will probably not use this since
        // i rather limit the input options a user has than to let them fiddle and just reply with errors until i get what is needed, but i want to avoid not having it in case i (need to)
        // change my mind of handling behavior. 
        public int Rating { get; set; }


        #endregion

    }


}