using System.ComponentModel.DataAnnotations;

public class RegistrationDateAttribute : ValidationAttribute
{
    public override bool IsValid(object value)
    {
        DateTime date = (DateTime)value;

        if (date.Date <= DateTime.Now.Date)
        {
            ErrorMessage = "The date must be later than today!";
            return false;
        }

        if (date.Date.DayOfWeek == DayOfWeek.Saturday || date.Date.DayOfWeek == DayOfWeek.Sunday)
        {
            ErrorMessage = "Sorry, it's a weekend! Choose another date";
            return false;
        }

        return true;
    }
}

public class CourseDateValidationAttribute : ValidationAttribute
{
    public override bool IsValid(object value)
    {
        RegistrationModel registrationModel = (RegistrationModel)value;

        if (registrationModel.Course.Equals( RegistrationModel.Courses.Basics) && registrationModel.DesirableDate.DayOfWeek == DayOfWeek.Monday)
        {
            ErrorMessage = "You can't register for consultaion on course \"Basics\" on Mondays!";
            return false;
        }

        return true;
    }
}
[CourseDateValidation]
public class RegistrationModel
{
    public enum Courses
    {
        JavaScript,
        [Display(Name = "C#")]
        CSharp,
        Java,
        Python,
        Basics
    }
    
    [Required (ErrorMessage = "Enter your first name, please")]
    [DataType(DataType.Text)]
    [StringLength(50, MinimumLength = 3, ErrorMessage = "Length must be less than 3 and more than 50 characters")]
    public string FirstName { get; set;}    
    
    [Required (ErrorMessage = "Enter your last name, please")]
    [DataType(DataType.Text)]
    [StringLength(50, MinimumLength = 3, ErrorMessage = "Length must be less than 3 and more than 50 characters")]
    public string LastName { get; set;}

	[Required(ErrorMessage = "Enter your email, please")]
	[DataType(DataType.EmailAddress)]
	[RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,63}$", ErrorMessage = "Enter a valid email address.")]
	public string Email { get; set; }

	[Required (ErrorMessage = "Enter the date to visit the consultation, please")]
    [DataType(DataType.Date)]
    [RegistrationDate]
    public DateTime DesirableDate { get; set;}

    public Courses Course { get; set;}
    
    public RegistrationModel()
    {
        DesirableDate = DateTime.Now;
    }
}