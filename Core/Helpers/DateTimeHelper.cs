namespace Domain.Helpers;

public static class DateTimeHelper
{

    public static int CalculateAge(DateTime birthDate)
    {
        int age = DateTime.Now.Year - birthDate.Year;
        if (DateTime.Now.DayOfYear < birthDate.DayOfYear)
            age--;

        return age;
    }

}