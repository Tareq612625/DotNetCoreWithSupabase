using DotNetCoreWithSuperbase.Models;
using Newtonsoft.Json;

namespace DotNetCoreWithSuperbase.Service
{
    public class SupabaseConnection
    {
        private readonly Supabase.Client _supabase;
        public SupabaseConnection()
        {
            //Supabase Credential  
            var url = "https://lbwulueormbjigcgubbc.supabase.co";
            var key = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6Imxid3VsdWVvcm1iamlnY2d1YmJjIiwicm9sZSI6ImFub24iLCJpYXQiOjE3MDk3MTM1MTcsImV4cCI6MjAyNTI4OTUxN30.uJh7kLMJvfk1nz9g3HiC_TAAqujPZCwvO9BlnBnvqIo";

            var options = new Supabase.SupabaseOptions
            {
                AutoConnectRealtime = true
            };

            _supabase = new Supabase.Client(url, key, options);
        }
        //Supabase Get Data
        public async Task<List<Student>> GetStudentListDataAsync()
        {
            var result = await _supabase.From<Student>().Get();
            var students = result.Models.ToList();
            return students;
        }
        //Supabase Data Insert
        public async void CreateStudent(Student obj)
        {
            await _supabase.From<Student>().Insert(obj);
        }
        //Supabase Function Call 
        public async Task<List<Student>> GetStudentListbyFunction()
        {
            var response = await _supabase.Rpc("select_students", null);
            string jsonContent = response.Content;
            List<Student> students = JsonConvert.DeserializeObject<List<Student>>(jsonContent);
            return students;
        }
    }
}
