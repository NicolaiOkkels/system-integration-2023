using CsvHelper.Configuration;

public class PersonClassMap : ClassMap<Person>{
    public PersonClassMap(){
        Map(m => m.Name).Name("name");
        Map(m => m.Age).Name("age");
        Map(m => m.Hobbies).Name("hobbies");
    }
}