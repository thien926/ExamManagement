using ExamManagerWinform.DTOs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamManagerWinform.DAOs
{
    class ResultDAO
    {
        private static ResultDAO instance;
        private string connectSTR = "Data Source=.\\SQLEXPRESS; Initial Catalog=EXAMDB;Integrated Security=true; uid=sa; password=1234567890";
        internal static ResultDAO Instance { get => (instance == null) ? (instance = new ResultDAO()) : instance; private set => instance = value; }

        private ResultDAO() { }
        public DataTable GetWithRoomId(int roomId) {
            // var sql = "SELECT s.Id, s.name as [Tên thí sinh], s.gender as [Giới tính], s.phone as [Số điện thoại], s.bornDate as [Ngày sinh]" +
            //     ", s.citizenCard as [CCCD], s.issueDate as [Ngày cấp], s.issuePlace as [Nơi cấp], s.email as [Mail], r.examRoom as [Phòng thi], " +
            //     "r.SBD, r.pointListen FROM Students as s, Results as r WHERE r.studentId = s.Id and r.roomId = {0}";
            string query = string.Format("SELECT s.Id, s.name as [Tên thí sinh], s.gender as [Giới tính], s.phone as [Số điện thoại], s.bornDate as [Ngày sinh]" +
                ", s.citizenCard as [CCCD], s.issueDate as [Ngày cấp], s.issuePlace as [Nơi cấp], s.email as [Mail], r.examRoom as [Phòng thi], " +
                "r.SBD, r.pointListen as [Điểm nghe], r.pointSpeak as [Điểm nói], r.pointWrite as [Điểm viết], r.pointRead as [Điểm đọc] FROM Students as s, Results as r WHERE r.studentId = s.Id and r.roomId = {0}", roomId);
            var res = DataProvider.Instance.ExcuteQuery(query);
            return res;
        }

        public DataTable GetWithNameRoomAndExaminationId(string name, int examinationId) {
            string query = string.Format("SELECT s.Id, s.name as [Tên thí sinh], s.gender as [Giới tính], s.phone as [Số điện thoại], s.bornDate as [Ngày sinh]" +
                ", s.citizenCard as [CCCD], s.issueDate as [Ngày cấp], s.issuePlace as [Nơi cấp], s.email as [Mail], r.examRoom as [Phòng thi], " +
                "r.SBD, r.pointListen as [Điểm nghe], r.pointSpeak as [Điểm nói], r.pointWrite as [Điểm viết], r.pointRead as [Điểm đọc] FROM Students as s, Results as r, Rooms as room WHERE r.roomId = room.Id and r.studentId = s.Id and room.name = '{0}' and room.examinationId = {1}", name, examinationId);
            var res = DataProvider.Instance.ExcuteQuery(query);
            return res;
        }

        public Boolean AddResult(ResultDTO data)
        {
            // string query = string.Format("INSERT INTO [dbo].[Results] ([examRoom], [SBD], [pointListen], [pointSpeak], [pointWrite], [pointRead], [roomId], [studentId], [registionFormId]) VALUES ('{0}', '{1}', {2}, {3}, {4}, {5}, {6}, {7}, {8})", 
            // data.examRoom, data.SBD, data.pointListen, data.pointSpeak, data.pointWrite, data.pointRead, data.roomId, data.studentId, data.registionFormId);
            string query = string.Format("INSERT INTO [dbo].[Results] ([examRoom], [SBD], [roomId], [studentId], [registionFormId]) VALUES ('{0}', '{1}', {2}, {3}, {4})", 
            data.examRoom, data.SBD, data.roomId, data.studentId, data.registionFormId);
            int res = DataProvider.Instance.ExcuteNonQuery(query);

            return res > 0;
        }

        public Boolean UpdateResult(ResultDTO data)
        {
            string query = string.Format("UPDATE [dbo].[Results] SET [examRoom] = '{0}' , [SBD] = '{1}' , [pointListen] = {2} , [pointSpeak] = {3} , [pointWrite] = {4} , [pointRead] = {5} , [roomId] = {6} , [studentId] = {7} , [registionFormId] = {8}  WHERE [Id] = {9} ", 
            data.examRoom, data.SBD, data.pointListen, data.pointSpeak, data.pointWrite, data.pointRead, data.roomId, data.studentId, data.registionFormId, data.Id);
            int res = DataProvider.Instance.ExcuteNonQuery(query);

            return res > 0;
        }

        public Boolean CheckSortInRoom(int examinationId, int levelId) {
            string query = string.Format("SELECT count(*) FROM Results as s WHERE s.roomId in (SELECT [Id] FROM Rooms as r 	WHERE r.examinationId = {0} and r.levelId = {1})", examinationId, levelId);
            int res = DataProvider.Instance.ExcuteScalar(query);

            return res > 0;
        }
    }
}
