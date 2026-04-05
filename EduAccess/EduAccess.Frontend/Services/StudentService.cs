using EduAccess.Application.DTOs;
using EduAccess.Domain.Entities;
using System.Net.Http.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduAccess.Frontend.Services
{
    public class StudentService
    {
        private readonly HttpClient _http;

        public StudentService(HttpClient http)
        {
            _http = http;
        }

        // 1. OBTENER TODOS LOS ESTUDIANTES
        // Llama a: GetStudentsController -> api/GetStudents
        public async Task<List<StudentResponseDto>> GetStudentsAsync()
        {
            try
            {
                var response = await _http.GetFromJsonAsync<List<StudentResponseDto>>("api/GetStudents");
                return response ?? new List<StudentResponseDto>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al listar: {ex.Message}");
                return new List<StudentResponseDto>();
            }
        }

        // 2. OBTENER UN ESTUDIANTE PORsu ID (Necesario para cargar el formulario de edición)
        // Llama a: GetStudentsController -> api/GetStudents/{id}
        public async Task<Student?> GetStudentByIdAsync(int id)
        {
            try
            {
                return await _http.GetFromJsonAsync<Student>($"api/GetStudents/{id}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener por ID: {ex.Message}");
                return null;
            }
        }

        // 3. CREAR UN NUEVO ESTUDIANTE
        // Llama a: CreateStudentController -> api/CreateStudent
        public async Task CreateStudentAsync(Student student)
        {
            try
            {
                await _http.PostAsJsonAsync("api/CreateStudent", student);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al crear: {ex.Message}");
            }
        }

        // 4. ACTUALIZAR UN ESTUDIANTE EXISTENTE (Editar)
        // Llama a: UpdateStudentController -> api/UpdateStudent/{id}
        public async Task UpdateStudentAsync(int id, Student student)
        {
            try
            {
                var response = await _http.PutAsJsonAsync($"api/UpdateStudent/{id}", student);
                if (!response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Error en la actualización en el servidor.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error de red al editar: {ex.Message}");
            }
        }

        // 5. BORRAR UN ESTUDIANTE
        // Llama a: DeleteStudentController -> api/DeleteStudent/{id}
        public async Task DeleteStudentAsync(int id)
        {
            try
            {
                await _http.DeleteAsync($"api/DeleteStudent/{id}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al borrar: {ex.Message}");
            }
        }
    }
}