using ExamManagerWinform.DAOs;
using ExamManagerWinform.DTOs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamManagerWinform.BUSs
{
    class RoomBUS
    {
        public DataTable GetAll()
        {
            return RoomDAO.Instance.GetAll();
        }

        public Boolean AddRoom(string name, int examinationId, int levelId, int amount)
        {
            var data = new RoomDTO();
            data.name = name;
            data.examinationId = examinationId;
            data.levelId = levelId;
            data.amount = amount;
            return RoomDAO.Instance.AddRoom(data);
            
        }

        public Boolean UpdateRoom(int Id, string name, int examinationId, int levelId, int amount)
        {
            var data = new RoomDTO();
            data.Id = Id;
            data.name = name;
            data.examinationId = examinationId;
            data.levelId = levelId;
            data.amount = amount;
            return RoomDAO.Instance.UpdateRoom(data);

        }

        public Boolean DeleteRoom(int Id)
        {
            return RoomDAO.Instance.DeleteRoom(Id);
        }

        public IEnumerable<RoomDTO> getByExamAndLevel(int examinationId, int levelId) {
            return RoomDAO.Instance.getByExamAndLevel(examinationId, levelId);
        }

        public Boolean isCreateRoom(int examinationId, int levelId) {
            return RoomDAO.Instance.isCreateRoom(examinationId, levelId);
        }

        public string[] getAllForStudent(int examinationId) {
            return RoomDAO.Instance.getAllForStudent(examinationId);
        }
    }
}
