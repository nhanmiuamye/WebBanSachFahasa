﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace WebBanSachFahasa.Models
{
    public class NHACCNHAP
    {
        public string conf = WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        public string ID { get; set; }
        public string Ten { get; set; }
        public string DC { get; set; }
        public string SDT { get; set; }
        public string mota { get; set; }
        public string STK { get; set; }
        public string kyhd { get; set; }
        public string kyhmhd { get; set; }
        public List<NHACCNHAP> getData(string mancc)
        {
            List<NHACCNHAP> listBH = new List<NHACCNHAP>();
            SqlConnection con = new SqlConnection(conf);
            SqlCommand cmd = new SqlCommand("select * from NHACCNHAP where disabled=0 and mancc='" + mancc + "'", con);
            cmd.CommandType = CommandType.Text;
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                NHACCNHAP emp = new NHACCNHAP();
                emp.ID = dr.GetValue(0).ToString();
                emp.Ten = dr.GetValue(1).ToString();
                listBH.Add(emp);
            }
            con.Close();
            return listBH;
        }
        public List<NHACCNHAP> getData()
        {
            List<NHACCNHAP> listBH = new List<NHACCNHAP>();
            SqlConnection con = new SqlConnection(conf);
            SqlCommand cmd = new SqlCommand("select * from NHACCNHAP where disabled=0", con);
            cmd.CommandType = CommandType.Text;
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                NHACCNHAP emp = new NHACCNHAP();
                emp.ID = dr.GetValue(0).ToString();
                emp.Ten = dr.GetValue(1).ToString();
                listBH.Add(emp);
            }
            con.Close();
            return listBH;
        }
        public int ktra2(string matg)
        {
            int dr = 0;
            SqlConnection con = new SqlConnection(conf);
            SqlCommand cmd2 = new SqlCommand("select count(*) from NHACCNHAP where MANCC = '" + matg + "'", con);
            cmd2.CommandType = CommandType.Text;
            con.Open();
            Object kq = cmd2.ExecuteScalar();
            con.Close();
            return int.Parse(kq.ToString());

        }
        public int them(string ma, string ten, string dc, string sdt, string mota, string stk, string nguoitao, string kyhd, string kyhmhd)
        {
            int dr = 0;
            SqlConnection con = new SqlConnection(conf);
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into NHACCNHAP(MANCC,TENCC,DC,SDT,MOTA,STK,NGUOITAO,KYHIEUHD,KYHIEUMAUDH) values(N'" + ma + "',N'" + ten + "',N'" + dc + "',N'" + sdt + "',N'" + mota + "',N'" + stk + "',N'" + nguoitao + "','" + kyhd + "','" + kyhmhd + "')", con);
            cmd.CommandType = CommandType.Text;
            dr = cmd.ExecuteNonQuery();
            con.Close();
            return dr;
        }
        public List<NHACCNHAP> getData3(string id)
        {
            List<NHACCNHAP> listBH = new List<NHACCNHAP>();
            SqlConnection con = new SqlConnection(conf);
            SqlCommand cmd = new SqlCommand("select * from NHACCNHAP where MANCC='" + id + "'", con);
            cmd.CommandType = CommandType.Text;
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                NHACCNHAP emp = new NHACCNHAP();
                emp.ID = dr.GetValue(0).ToString();
                emp.Ten = dr.GetValue(1).ToString();
                emp.DC = dr.GetValue(2).ToString();
                emp.mota = dr.GetValue(5).ToString();
                emp.STK = dr.GetValue(3).ToString();
                emp.SDT = dr.GetValue(4).ToString();
                emp.kyhd = dr.GetValue(6).ToString();
                emp.kyhmhd = dr.GetValue(7).ToString();
                listBH.Add(emp);
            }
            con.Close();
            return listBH;
        }
        public int update(string ma, string ten, string dc, string sdt, string mota, string gt, string nguoitao, string kyhd, string kyhmhd)
        {
            int dr = 0;
            SqlConnection con = new SqlConnection(conf);
            con.Open();
            SqlCommand cmd = new SqlCommand("update NHACCNHAP set TENNCC = N'" + ten + "',DC= N'" + dc + "',SDT = '" + sdt + "',MOTA = '" + mota + "',stk = '" + gt + "',NGUOISUA = '" + nguoitao + "',KYHIEUHD = '" + kyhd + "',KYHIEUMAUDH = '" + kyhmhd + "' where MANCC='" + ma + "'", con);
            cmd.CommandType = CommandType.Text;
            dr = cmd.ExecuteNonQuery();
            con.Close();
            return dr;
        }
        public List<NHACCNHAP> getData2()
        {
            List<NHACCNHAP> listBH = new List<NHACCNHAP>();
            SqlConnection con = new SqlConnection(conf);
            SqlCommand cmd = new SqlCommand("select * from NHACCNHAP", con);
            cmd.CommandType = CommandType.Text;
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                NHACCNHAP emp = new NHACCNHAP();
                emp.ID = dr.GetValue(0).ToString();
                emp.Ten = dr.GetValue(1).ToString();
                emp.DC = dr.GetValue(2).ToString();
                emp.mota = dr.GetValue(5).ToString();
                emp.STK = dr.GetValue(3).ToString();
                emp.SDT = dr.GetValue(4).ToString();
                emp.kyhd = dr.GetValue(6).ToString();
                emp.kyhmhd = dr.GetValue(7).ToString();
                listBH.Add(emp);
            }
            con.Close();
            return listBH;
        }
    }
}