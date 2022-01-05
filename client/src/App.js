
import './App.css';
import Register from './pages/Register/Register';
import Result from './pages/Result/Result';

function App() {

  return (
    <div>

      <nav className="navbar navbar-inverse">
        <ul className="nav navbar-nav">
          <li className="active">
            <a href="#">Đăng ký</a>
          </li>
          <li>
            <a href="#">Kết quả</a>
          </li>
          <li>
            <a href="#">Danh sách dự thi</a>
          </li>
          <li>
            <a href="#">Thống kê</a>
          </li>
        </ul>
      </nav>
      
      
      <div className="container">
        {/* <Register /> */}
        <Result />
      </div>
      

    </div>
  );
}

export default App;
