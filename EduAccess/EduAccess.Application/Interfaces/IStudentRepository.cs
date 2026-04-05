using EduAccess.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduAccess.Application.Interfaces
{
    public interface IStudentRepository
    {
        // Obtener la lista de todos los estudiantes
        Task<IEnumerable<Student>> GetAllAsync();

        // Obtener un estudiante específico por su ID
        Task<Student?> GetByIdAsync(int id);

        // Crear un nuevo estudiante (Debe coincidir con CreateStudentController)
        Task<Student> CreateAsync(Student student);

        // Actualizar datos de un estudiante (Debe coincidir con UpdateStudentController)
        Task<bool> UpdateAsync(Student student);

        // Eliminar un estudiante de la base de datos
        Task<bool> DeleteAsync(int id);
    }
}