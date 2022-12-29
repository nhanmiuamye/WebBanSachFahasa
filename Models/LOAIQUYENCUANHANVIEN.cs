﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace WebBanSachFahasa.Models
{
    public class LOAIQUYENCUANHANVIEN
    {
        public string conf = WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        public string ID { get; set; }
        public string Ma { get; set; }
        public string Ten { get; set; }
        public List<LOAIQUYENCUANHANVIEN> getData2(string ma, string quyen)
        {
            List<LOAIQUYENCUANHANVIEN> listBH = new List<LOAIQUYENCUANHANVIEN>();
            SqlConnection con = new SqlConnection(conf);
            SqlCommand cmd = new SqlCommand("select LOAIQUYEN.IDLOAIQUYEN,MALOAIQUYEN,TenLoaiQuyen from LOAIQUYENOFNHANVIEN,NHANVIEN,LOAIQUYEN where LOAIQUYENOFNHANVIEN.MANV =  NHANVIEN.MANV and LOAIQUYEN.IDLOAIQUYEN = LOAIQUYENOFNHANVIEN.IDLOAIQUYEN and NHANVIEN.IDQUYEN = '" + quyen + "' and nhanvien.manv='" + ma + "' and LOAIQUYENOFNHANVIEN.disabled = 0 and LOAIQUYEN.IDLOAIQUYEN IN (select IDLOAIQUYEN from LOAIQUYENOFQUYEN where IDQUYEN='" + quyen + "' and disabled = 0)", con);
            cmd.CommandType = CommandType.Text;
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                LOAIQUYENCUANHANVIEN emp = new LOAIQUYENCUANHANVIEN();
                emp.ID = dr.GetValue(0).ToString();
                emp.Ma = dr.GetValue(1).ToString();
                emp.Ten = dr.GetValue(2).ToString();
                listBH.Add(emp);
            }
            con.Close();
            return listBH;
        }
        public List<LOAIQUYENCUANHANVIEN> getData3(string ma)
        {
            List<LOAIQUYENCUANHANVIEN> listBH = new List<LOAIQUYENCUANHANVIEN>();
            SqlConnection con = new SqlConnection(conf);
            SqlCommand cmd = new SqlCommand("select LOAIQUYEN.IDLOAIQUYEN,MALOAIQUYEN,TenLoaiQuyen from LOAIQUYENOFNHANVIEN,NHANVIEN,LOAIQUYEN where LOAIQUYENOFNHANVIEN.MANV =  NHANVIEN.MANV and LOAIQUYEN.IDLOAIQUYEN = LOAIQUYENOFNHANVIEN.IDLOAIQUYEN and nhanvien.manv='" + ma + "' and LOAIQUYENOFNHANVIEN.disabled = 1", con);
            cmd.CommandType = CommandType.Text;
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                LOAIQUYENCUANHANVIEN emp = new LOAIQUYENCUANHANVIEN();
                emp.ID = dr.GetValue(0).ToString();
                emp.Ma = dr.GetValue(1).ToString();
                emp.Ten = dr.GetValue(2).ToString();
                listBH.Add(emp);
            }
            con.Close();
            return listBH;
        }
        public List<LOAIQUYENCUANHANVIEN> getData5(string ma, string quyen)
        {
            List<LOAIQUYENCUANHANVIEN> listBH = new List<LOAIQUYENCUANHANVIEN>();
            SqlConnection con = new SqlConnection(conf);
            SqlCommand cmd = new SqlCommand("select LOAIQUYEN.IDLOAIQUYEN,MALOAIQUYEN,TenLoaiQuyen from LOAIQUYENOFNHANVIEN,NHANVIEN,LOAIQUYEN where LOAIQUYENOFNHANVIEN.MANV =  NHANVIEN.MANV and LOAIQUYEN.IDLOAIQUYEN = LOAIQUYENOFNHANVIEN.IDLOAIQUYEN and nhanvien.manv='" + ma + "' and LOAIQUYENOFNHANVIEN.disabled = 0 and LOAIQUYEN.IDLOAIQUYEN NOT IN (select IDLOAIQUYEN from LOAIQUYENOFQUYEN where IDQUYEN='" + quyen + "' and disabled = 0)", con);
            cmd.CommandType = CommandType.Text;
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                LOAIQUYENCUANHANVIEN emp = new LOAIQUYENCUANHANVIEN();
                emp.ID = dr.GetValue(0).ToString();
                emp.Ma = dr.GetValue(1).ToString();
                emp.Ten = dr.GetValue(2).ToString();
                listBH.Add(emp);
            }
            con.Close();
            return listBH;
        }
        public List<LOAIQUYENCUANHANVIEN> getData4(string ma)
        {
            List<LOAIQUYENCUANHANVIEN> listBH = new List<LOAIQUYENCUANHANVIEN>();
            SqlConnection con = new SqlConnection(conf);
            SqlCommand cmd = new SqlCommand("select IDLOAIQUYEN,MALOAIQUYEN,TenLoaiQuyen from LOAIQUYEN where IDLOAIQUYEN not in (select IDLOAIQUYEN from LOAIQUYENOFNHANVIEN where manv='" + ma + "')", con);
            cmd.CommandType = CommandType.Text;
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                LOAIQUYENCUANHANVIEN emp = new LOAIQUYENCUANHANVIEN();
                emp.ID = dr.GetValue(0).ToString();
                emp.Ma = dr.GetValue(1).ToString();
                emp.Ten = dr.GetValue(2).ToString();
                listBH.Add(emp);
            }
            con.Close();
            return listBH;
        }
        public int them(int maloaiquyen, string manv)
        {
            int dr = 0;
            SqlConnection con = new SqlConnection(conf);
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into LOAIQUYENOFNHANVIEN(MANV,IDLOAIQUYEN) values(N'" + manv + "','" + maloaiquyen + "')", con);
            cmd.CommandType = CommandType.Text;
            dr = cmd.ExecuteNonQuery();
            con.Close();
            return dr;
        }
        public int update(int maloaiquyen, string manv)
        {
            int dr = 0;
            SqlConnection con = new SqlConnection(conf);
            con.Open();
            SqlCommand cmd = new SqlCommand("update LOAIQUYENOFNHANVIEN set disabled = 0 where manv='" + manv + "' and IDLOAIQUYEN ='" + maloaiquyen + "'", con);
            cmd.CommandType = CommandType.Text;
            dr = cmd.ExecuteNonQuery();
            con.Close();
            return dr;
        }
        public int update2(int maloaiquyen, string manv)
        {
            int dr = 0;
            SqlConnection con = new SqlConnection(conf);
            con.Open();
            SqlCommand cmd = new SqlCommand("update LOAIQUYENOFNHANVIEN set disabled = 1 where manv='" + manv + "' and IDLOAIQUYEN ='" + maloaiquyen + "'", con);
            cmd.CommandType = CommandType.Text;
            dr = cmd.ExecuteNonQuery();
            con.Close();
            return dr;
        }
        public int getDataQuyenNV(string manv, string ma_loaiquyen)
        {
            int dr = 0;
            SqlConnection con = new SqlConnection(conf);
            SqlCommand cmd2 = new SqlCommand("select count(*) from LOAIQUYENOFNHANVIEN,LOAIQUYEN where manv='" + manv + "' and MALOAIQUYEN='" + ma_loaiquyen + "' and LOAIQUYENOFNHANVIEN.IDLOAIQUYEN = LOAIQUYEN.IDLOAIQUYEN", con);
            cmd2.CommandType = CommandType.Text;
            con.Open();
            Object kq = cmd2.ExecuteScalar();

            if (kq.Equals(0))
            {
                dr = 0;
            }
            else
            {
                dr = 1;
            }
            con.Close();
            return dr;
        }
    }
}