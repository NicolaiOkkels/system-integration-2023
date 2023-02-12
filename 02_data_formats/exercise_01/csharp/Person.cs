public class Person
{
    public string? Name { get; set; }
    public int? Age { get; set; }
    public string[]? Hobbies { get; set; }

    public override string ToString()
    {
        if (Hobbies != null)
        {
            return "Person: " + Name + ", " + Age + ", " + "Hobbies[" + string.Join(", ", Hobbies) + "]";
        }
        else
        {
            return "Person: " + Name + ", " + Age + ", " + "No hobbies";
        }
    }
}
