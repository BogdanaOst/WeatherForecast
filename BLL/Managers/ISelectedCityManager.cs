using DAL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Managers
{
    public interface ISelectedCityManager
    {
        Task<List<SelectedCityDTO>> GetAllAsync();
        Task<SelectedCityDTO> GetByIdAsync(int? id);
        Task AddAsync(SelectedCityDTO city_dto);
        Task Update(SelectedCityDTO city_dto);
        Task DeleteAsync(int id);
        void Dispose();
    }
}
