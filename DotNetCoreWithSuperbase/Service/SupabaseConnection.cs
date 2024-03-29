﻿using DotNetCoreWithSuperbase.Models;

namespace DotNetCoreWithSuperbase.Service
{
    public class SupabaseConnection
    {
        private readonly Supabase.Client _supabase;
        public SupabaseConnection()
        {
            var url = "https://lbwulueormbjigcgubbc.supabase.co";
            var key = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6Imxid3VsdWVvcm1iamlnY2d1YmJjIiwicm9sZSI6ImFub24iLCJpYXQiOjE3MDk3MTM1MTcsImV4cCI6MjAyNTI4OTUxN30.uJh7kLMJvfk1nz9g3HiC_TAAqujPZCwvO9BlnBnvqIo";

            var options = new Supabase.SupabaseOptions
            {
                AutoConnectRealtime = true
            };

            _supabase = new Supabase.Client(url, key, options);
        }
        public async Task InitializeAsync()
        {
            await _supabase.InitializeAsync();
        }
        public async Task<List<Student>> GetStudentListDataAsync()
        {
            var result = await _supabase.From<Student>().Get();
            var students = result.Models.ToList();
            return students;
        }
        public async void CreateStudent(Student obj)
        {
            await _supabase.From<Student>().Insert(obj);
        }
    }
}
