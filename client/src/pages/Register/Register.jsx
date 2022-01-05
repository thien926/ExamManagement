import React from 'react'
import './Register.css'

function Register() {
    return (
        <form className="form-horizontal">
            <h2 className='text-center'>Đăng ký</h2>
            <div className="form-group">
                <label htmlFor="name" className="col-sm-3 ">Họ và tên</label>
                <div className="col-sm-9">
                    <input type="text" id="name" placeholder="Họ và tên" className="form-control" autofocus />
                </div>
            </div>
            <div className="form-group">
                <label htmlFor="phone" className="col-sm-3 ">Số điện thoại</label>
                <div className="col-sm-9">
                    <input type="text" id="phone" placeholder="Số điện thoại" className="form-control" autofocus />
                </div>
            </div>
            <div className="form-group">
                <label htmlFor="birthDate" className="col-sm-3 ">Ngày sinh</label>
                <div className="col-sm-9">
                    <input type="date" id="birthDate" className="form-control" />
                </div>
            </div>
            <div className="form-group">
                <label htmlFor="CCCD" className="col-sm-3 ">CCCD</label>
                <div className="col-sm-9">
                    <input type="text" id="CCCD" placeholder="CCCD" className="form-control" autofocus />
                </div>
            </div>
            <div className="form-group">
                <label htmlFor="birthDate" className="col-sm-3 ">Ngày cấp</label>
                <div className="col-sm-9">
                    <input type="date" id="birthDate" className="form-control" />
                </div>
            </div>
            <div className="form-group">
                <label htmlFor="CCCD" className="col-sm-3 ">Nơi cấp</label>
                <div className="col-sm-9">
                    <input type="text" id="Nơi cấp" placeholder="Nơi cấp" className="form-control" autofocus />
                </div>
            </div>
            <div className="form-group">
                <label htmlFor="email" className="col-sm-3 ">Email</label>
                <div className="col-sm-9">
                    <input type="email" id="email" placeholder="Email" className="form-control" />
                </div>
            </div>
            <div className="form-group">
                <label className=" col-sm-3">Giới tính</label>
                <div className="col-sm-6">
                    <div className="row">
                        <div className="col-sm-4">
                            <label className="radio-inline">
                                <input type="radio" id="femaleRadio" defaultValue="Female" />Nam
                            </label>
                        </div>
                        <div className="col-sm-4">
                            <label className="radio-inline">
                                <input type="radio" id="maleRadio" defaultValue="Male" />Nữ
                            </label>
                        </div>
                        {/* <div className="col-sm-4">
                            <label className="radio-inline">
                                <input type="radio" id="uncknownRadio" defaultValue="Unknown" />Unknown
                            </label>
                        </div> */}
                    </div>
                </div>
            </div>
            <div className="form-group">
                <label htmlFor="country" className="col-sm-3 ">Khóa thi</label>
                <div className="col-sm-9">
                    <select id="country" className="form-control">
                        <option>Afghanistan</option>
                        <option>Bahamas</option>
                        <option>Cambodia</option>
                        <option>Denmark</option>
                        <option>Ecuador</option>
                        <option>Fiji</option>
                        <option>Gabon</option>
                        <option>Haiti</option>
                    </select>
                </div>
            </div>
            <div className="form-group">
                <label htmlFor="country" className="col-sm-3 ">Trình độ</label>
                <div className="col-sm-9">
                    <select id="country" className="form-control">
                        <option>A2</option>
                        <option>B1</option>
                    </select>
                </div>
            </div>
            <div className="form-group">
                <div className="col-sm-9 col-sm-offset-3">
                    <button type="submit" className="btn btn-primary btn-block">Register</button>
                </div>
            </div>
        </form>

    )
}

export default Register
