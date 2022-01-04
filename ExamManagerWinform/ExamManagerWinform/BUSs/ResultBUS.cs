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
    class ResultBUS
    {
        public Boolean AddResult(string examRoom, string SBD, float pointListen, float pointSpeak, float pointWrite, float pointRead, int roomId, int studentId, int registionFormId)
        {
            var data = new ResultDTO();
            data.examRoom = examRoom;
            data.SBD = SBD;
            data.pointListen = pointListen;
            data.pointSpeak = pointSpeak;
            data.pointWrite = pointWrite;
            data.pointRead = pointRead;
            data.roomId = roomId;
            data.studentId = studentId;
            data.registionFormId = registionFormId;
            return ResultDAO.Instance.AddResult(data);
            
        }

        public Boolean UpdateResult(int Id, string examRoom, string SBD, float pointListen, float pointSpeak, float pointWrite, float pointRead, int roomId, int studentId, int registionFormId)
        {
            var data = new ResultDTO();
            data.Id = Id;
            data.examRoom = examRoom;
            data.SBD = SBD;
            data.pointListen = pointListen;
            data.pointSpeak = pointSpeak;
            data.pointWrite = pointWrite;
            data.pointRead = pointRead;
            data.roomId = roomId;
            data.studentId = studentId;
            data.registionFormId = registionFormId;
            return ResultDAO.Instance.UpdateResult(data);

        }

        public Boolean CheckSortInResult(int examinationId, int levelId) {
            return ResultDAO.Instance.CheckSortInRoom(examinationId, levelId);
        }

        public DataTable GetWithRoomId(int roomId)
        {
            return ResultDAO.Instance.GetWithRoomId(roomId);
        }

        public DataTable GetWithNameRoomAndExaminationId(string name, int examinationId) {
            return ResultDAO.Instance.GetWithNameRoomAndExaminationId(name, examinationId);
        }
    }
}
