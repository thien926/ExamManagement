import React from 'react'
// import './Result.css'

function Result() {
    return (
        <div>
            <div className="row text-center">
                <h2>Kết quả thi</h2>
            </div>

            <div className="row">
                <form method="POST">
                    <div className="form-group">
                        <label>Họ tên</label>
                        <input type="text" className="form-control" placeholder="Nhập họ tên" />
                    </div>
                    <div className="form-group">
                        <label>Số điện thoại</label>
                        <input type="text" className="form-control" placeholder="Nhập số điện thoại" />
                    </div>
                    <button type="submit" className="btn btn-primary">Xem</button>
                </form>
            </div>

            <div className="row mt-3">
                <div className="col-xs-6 col-sm-6 col-md-6 col-lg-6 col-md-offset-3 col-xs-offset-3 col-sm-offset-3">
                    <div className="panel panel-primary">
                        <div className="panel-heading">
                            <h3 className="panel-title">
                                Thông tin thí sinh</h3>
                        </div>
                        <div className="panel-body">
                            <table className="table table-borderless" style={{borderTopStyle: 'none', borderBottomStyle:'none'}}>
                                <tbody>
                                    <tr>
                                        <td>Họ tên</td>
                                        <td>Nguyễn Ngọc Thiện</td>
                                    </tr>
                                    <tr>
                                        <td>Số điện thoại</td>
                                        <td>Nguyễn Ngọc Thiện</td>
                                    </tr>
                                    <tr>
                                        <td>Giới tính</td>
                                        <td>Nguyễn Ngọc Thiện</td>
                                    </tr>
                                    <tr>
                                        <td>Họ tên</td>
                                        <td>Nguyễn Ngọc Thiện</td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                    </div>

                </div>
            </div>

            
            <div className="row">
                
                <table className="table table-hover">
                    <thead>
                        <tr>
                            <th>Khóa thi</th>
                            <th>Phòng thi</th>
                            <th>SBD</th>
                            <th>Điểm nghe</th>
                            <th>Điểm nói</th>
                            <th>Điểm đọc</th>
                            <th>Điểm viết</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td>Khóa thi 1</td>
                            <td>A2P01</td>
                            <td>A2001</td>
                            <td>9.2</td>
                            <td>9</td>
                            <td>9.1</td>
                            <td>6.3</td>
                        </tr>
                        <tr>
                            <td>Khóa thi 1</td>
                            <td>A2P01</td>
                            <td>A2001</td>
                            <td>9.2</td>
                            <td>9</td>
                            <td>9.1</td>
                            <td>6.3</td>
                        </tr>
                        <tr>
                            <td>Khóa thi 1</td>
                            <td>A2P01</td>
                            <td>A2001</td>
                            <td>9.2</td>
                            <td>9</td>
                            <td>9.1</td>
                            <td>6.3</td>
                        </tr>
                        <tr>
                            <td>Khóa thi 1</td>
                            <td>A2P01</td>
                            <td>A2001</td>
                            <td>9.2</td>
                            <td>9</td>
                            <td>9.1</td>
                            <td>6.3</td>
                        </tr>
                        <tr>
                            <td>Khóa thi 1</td>
                            <td>A2P01</td>
                            <td>A2001</td>
                            <td>9.2</td>
                            <td>9</td>
                            <td>9.1</td>
                            <td>6.3</td>
                        </tr>
                    </tbody>
                </table>
                
            </div>
            

        </div>
    )
}

export default Result
