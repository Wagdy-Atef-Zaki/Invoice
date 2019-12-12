using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;

namespace my_project
{
    class ado_project
    {
        SqlConnection con;

        public ado_project()
        {
            con = new SqlConnection("Data Source=wagdy;Initial Catalog=project;Integrated Security=true");
        }




        #region items
        public void insert_items(string code,string name, string describtion, Int64 unit_value, Int64 current_quantaty, Int64 ideal_quantaty, Int64 warnning_quantaty)
        {
            con.Open();
            SqlCommand com = new SqlCommand("insert into items values('" + code + "','"+name+"','" + describtion + "','" + unit_value + "','" + current_quantaty + "','" + ideal_quantaty + "','" + warnning_quantaty + "')",con);
            com.ExecuteNonQuery();
            con.Close();
        }

        public void delete_items(string itemname)
        {
            con.Open();
            SqlCommand com = new SqlCommand("delete from items where item_name='"+itemname+"'", con);
            com.ExecuteNonQuery();
            con.Close();
        }

        public void select_id_itemname(string item_name, ref Int64 id)
        {
            id = 0;
            con.Open();
            SqlCommand com = new SqlCommand("select items_id from items where item_name='" + item_name + "'", con);
            SqlDataReader dr = com.ExecuteReader();
            if (dr.Read())
            { id = Int64.Parse(dr[0].ToString()); }
            else
            { id = 0; }
            dr.Close();
            con.Close();
        }

        public void update_item(string id,string code, string name, string describtion, double unit_value, Int64 current_quantaty, Int64 ideal_quantaty, Int64 warnning_quantaty)
        {
            con.Open();
            SqlCommand com = new SqlCommand("update items set item_code='" + code + "',item_name='" + name + "',item_describtion='" + describtion + "',unit_value='" + unit_value + "',current_quantaty='" + current_quantaty + "',ideal_quantaty='" + ideal_quantaty + "',warning_quantaty='" + warnning_quantaty + "' where item_code='" + id + "'", con);
            com.ExecuteNonQuery();
            con.Close();
        }


        #endregion



        #region customer

         public void insert_customer(string comp_name, string contact_person, string address, Int64 ph_primary, Int64 ph_alternative, string email, Int64 card_num, Int64 card_verification_num, string card_type, Int64 ex_month, Int64 ex_year, string cardholder_name, string shipping_address, string sales_person, string cust_note, string cust_group, double balance)
        {
            con.Open();
            SqlCommand com = new SqlCommand("insert into customer values('" + comp_name + "','" + contact_person + "','" + address + "'," + ph_primary + "," + ph_alternative + ",'" + email + "'," + card_num + "," + card_verification_num + ",'" + card_type + "'," + ex_month + "," + ex_year + ",'" + cardholder_name + "','" + shipping_address + "','" + sales_person + "','" + cust_note + "','" + cust_group + "'," + balance + ")", con);
            com.ExecuteNonQuery();
            con.Close();
        }


         public void insertgroup(string group)
        {
            con.Open();
            SqlCommand com = new SqlCommand("insert into groups values('" + group + "')", con);
            com.ExecuteNonQuery();
            con.Close();
        }

         public DataTable comboboxngroup()
        {
            SqlCommand com = new SqlCommand("select group_name,group_id from groups", con);
            DataTable dt = new DataTable();
            DataColumn dc1 = new DataColumn("group_id", typeof(Int64));
            DataColumn dc2 = new DataColumn("group_name", typeof(string));
            dt.Columns.Add(dc1);
            dt.Columns.Add(dc2);
            SqlDataAdapter da = new SqlDataAdapter(com);
            da.Fill(dt);
            return dt;
        } 

         public DataTable combo_opencust()
        {
            SqlCommand com = new SqlCommand("select group_name from groups", con);
            DataTable dt = new DataTable();  
            DataColumn dc1 = new DataColumn("group_name", typeof(string));
            dt.Columns.Add(dc1);      
            SqlDataAdapter da = new SqlDataAdapter(com);
            da.Fill(dt);
            return dt;
        }

       

         public void delete_customer(string comp_name)
         {
             try
             {
                 con.Open();
                 SqlCommand com = new SqlCommand("delete from customer where company_name='" + comp_name + "'", con);
                 com.ExecuteNonQuery();
                 con.Close();
             }
             catch(Exception)
             {MessageBox.Show("This company Have many invoices so you can't delete it");}
         }

         public void selectcustomer(Int64 id,string comp_name, string contact_person, string address, Int64 ph_primary, Int64 ph_alternative, string email, Int64 card_num, Int64 card_verification_num, string card_type, Int64 ex_month, Int64 ex_year, string cardholder_name, string currency_type, string shipping_address, string sales_person, string cust_note, string cust_group, Int64 balance)
         {
             id = 0 ; contact_person = ""; address = ""; ph_primary = 0; ph_alternative = 0; email = ""; card_num = 0; card_verification_num = 0; card_type = ""; ex_month = 0; ex_year = 0; cardholder_name = ""; currency_type = ""; shipping_address = ""; sales_person = ""; cust_note = ""; cust_group = ""; balance = 0;
             con.Open();
             SqlCommand com = new SqlCommand("select customer_id,contact_person,address,phone_primary,phone_puplic,e_mail,card_num,card_verification_num,card_type,expiration_month,expiration_year,cardholder_name,currency_type,shipping_address,sales_person,customer_notes,custmer_group,blance from customer where company_name='" + comp_name + "'", con);
             SqlDataReader dr = com.ExecuteReader();
             if (dr.Read())
             {
                 id = Int64.Parse(dr[0].ToString());
                 contact_person = dr[1].ToString();
                 address = dr[2].ToString();
                 ph_primary = Int64.Parse(dr[3].ToString());
                 ph_alternative = Int64.Parse(dr[4].ToString());
                 email = dr[5].ToString();
                 card_num = Int64.Parse(dr[6].ToString());
                 card_verification_num = Int64.Parse(dr[7].ToString());
                 card_type = dr[8].ToString();
                 ex_month = Int64.Parse(dr[9].ToString());
                 ex_year = Int64.Parse(dr[10].ToString());
                 cardholder_name = dr[11].ToString();
                 currency_type = dr[12].ToString();
                 shipping_address = dr[13].ToString();
                 sales_person = dr[14].ToString();
                 cust_note = dr[15].ToString();
                 cust_group = dr[16].ToString();
                 balance = Int64.Parse(dr[17].ToString());
             }
             else
             {
                 id = 0; 
                 contact_person = "null";
                 address = "null"; 
                 ph_primary = 0; 
                 ph_alternative = 0;
                 email = "null";
                 card_num = 0;
                 card_verification_num = 0;
                 card_type = "null";
                 ex_month = 0;
                 ex_year = 0; 
                 cardholder_name = "null";
                 currency_type = "null";
                 shipping_address = "null";
                 sales_person = "null"; 
                 cust_note = "null";
                 cust_group = "null"; 
                 balance = 0;
             }
             dr.Close();
             con.Close();
         }


         public void show_detail_customer(Int64 id,ref string comp_name,ref string contact_person,ref string address,ref Int64 ph_primary,ref Int64 ph_alternative,ref string email,ref Int64 card_num,ref Int64 card_verification_num,ref string card_type,ref Int64 ex_month,ref Int64 ex_year,ref string cardholder_name,ref string currency_type,ref string shipping_address,ref string sales_person,ref string cust_note,ref string cust_group,ref Int64 balance)
         {
             comp_name = ""; contact_person = ""; address = ""; ph_primary = 0; ph_alternative = 0; email = ""; card_num = 0; card_verification_num = 0; card_type = ""; ex_month = 0; ex_year = 0; cardholder_name = ""; currency_type = ""; shipping_address = ""; sales_person = ""; cust_note = ""; cust_group = ""; balance = 0;
             con.Open();
             SqlCommand com = new SqlCommand("select company_name,contact_person,address,phone_primary,phone_puplic,e_mail,card_num,card_verification_num,card_type,expiration_month,expiration_year,cardholder_name,currency_type,shipping_address,sales_person,customer_notes,custmer_group,blance from customer where customer_id='" + id + "'", con);
             SqlDataReader dr = com.ExecuteReader();
             if (dr.Read())
             {
                 comp_name =dr[0].ToString();
                 contact_person = dr[1].ToString();
                 address = dr[2].ToString();
                 ph_primary = Int64.Parse(dr[3].ToString());
                 ph_alternative = Int64.Parse(dr[4].ToString());
                 email = dr[5].ToString();
                 card_num = Int64.Parse(dr[6].ToString());
                 card_verification_num = Int64.Parse(dr[7].ToString());
                 card_type = dr[8].ToString();
                 ex_month = Int64.Parse(dr[9].ToString());
                 ex_year = Int64.Parse(dr[10].ToString());
                 cardholder_name = dr[11].ToString();
                 currency_type = dr[12].ToString();
                 shipping_address = dr[13].ToString();
                 sales_person = dr[14].ToString();
                 cust_note = dr[15].ToString();
                 cust_group = dr[16].ToString();
                 balance = Int64.Parse(dr[17].ToString());
             }
             else
             {
                 comp_name="null";
                 contact_person = "null";
                 address = "null";
                 ph_primary = 0;
                 ph_alternative = 0;
                 email = "null";
                 card_num = 0;
                 card_verification_num = 0;
                 card_type = "null";
                 ex_month = 0;
                 ex_year = 0;
                 cardholder_name = "null";
                 currency_type = "null";
                 shipping_address = "null";
                 sales_person = "null";
                 cust_note = "null";
                 cust_group = "null";
                 balance = 0;
             }
             dr.Close();
             con.Close();
         }
         public void update_customer(Int64 id, string comp_name, string contact_person, string address, Int64 ph_primary, Int64 ph_alternative, string email, Int64 card_num, Int64 card_verification_num, string card_type, Int64 ex_month, Int64 ex_year, string cardholder_name,  string shipping_address, string sales_person, string cust_note, string cust_group)
         {
             con.Open();
             SqlCommand com = new SqlCommand("update customer set company_name='" + comp_name + "', contact_person='" + contact_person + "',address='" + address + "',phone_primary=" + ph_primary + ",phone_puplic=" + ph_alternative + ",e_mail='" + email + "',card_num=" + card_num + ",card_verification_num=" + card_verification_num + ",card_type='" + card_type + "',expiration_month=" + ex_month + ",expiration_year=" + ex_year + ",cardholder_name='" + cardholder_name + "',shipping_address='" + shipping_address + "',sales_person='" + sales_person + "',customer_notes='" + cust_note + "',custmer_group='" + cust_group + "' where customer_id="+id+"", con);
             com.ExecuteNonQuery();
             con.Close();
         }

         public void select_id_Companyname(string comp_name, ref int id)
         {
             id = 0;
             con.Open();
             SqlCommand com = new SqlCommand("select customer_id from customer where company_name='"+comp_name+"'", con);
             SqlDataReader dr = com.ExecuteReader();
             if (dr.Read())
             { id = int.Parse(dr[0].ToString()); }
             else
             { id = 0; }
             dr.Close();
             con.Close();
         }

        #endregion




     #region invoice
		  public void insert_invoice(string comp_name,string contact_person,string address,Int64 phone,string shipto,string shipby,Int64 shipcost,string date,string date_d,Int64 bayment_in,string sales_person,string notes,double total,double paid,double change,string done,Int64 fkid )
       {
           con.Open();
           SqlCommand com = new SqlCommand("insert into invoice_1 values('" + comp_name + "','" + contact_person + "','" + address + "'," + phone + ",'" + shipto + "','" + shipby + "'," + shipcost + ",'" + date + "','" + date_d + "'," + bayment_in + ",'" + sales_person + "','" + notes + "'," + total + "," + paid + "," + change + ",'" + done + "'," +fkid+ ")", con);
           com.ExecuteNonQuery();
           con.Close();

       }


          public DataTable return_company_name()
          {
              SqlCommand com = new SqlCommand("select company_name from customer", con);
              DataTable dt = new DataTable();
             
              DataColumn dc1 = new DataColumn("company_name", typeof(string));
              dt.Columns.Add(dc1);
             
              SqlDataAdapter da = new SqlDataAdapter(com);
              da.Fill(dt);
              return dt;
          }


          public void select_data(string comp_name,ref string contact_person,ref string address,ref Int64 phone)
          {
              contact_person = ""; address = ""; phone = 0;
              con.Open();
              SqlCommand com = new SqlCommand("select contact_person,address,phone_primary from customer where company_name='"+comp_name+"'", con);
              SqlDataReader dr = com.ExecuteReader();
              if (dr.Read())
              {
                  phone = Int64.Parse(dr[2].ToString());
                  contact_person = dr[0].ToString();
                  address = dr[1].ToString();
              }
              else
              {
                  phone = 0;
                  contact_person = "";
                  address = "";
              }
              dr.Close();
              con.Close();
          }


          public void select_itemname(int name,ref Int64 number)
          {   number = 0;
              con.Open();

              SqlCommand com = new SqlCommand("select current_quantaty from items where items_id=" + name + "", con);
              SqlDataReader dr = com.ExecuteReader();
              if (dr.Read())
              { number = Int64.Parse(dr[0].ToString()); }
              else
              { number = 0; }
              dr.Close();
              con.Close();
 
          }
          //public void select_itemmname(int name, ref string number)
          //{
          //    number = "";
          //    con.Open();

          //    SqlCommand com = new SqlCommand("select item_name from items where items_id=" + name + "", con);
          //    SqlDataReader dr = com.ExecuteReader();
          //    if (dr.Read())
          //    { number = dr[0].ToString(); }
          //    else
          //    { number = ""; }
          //    dr.Close();
          //    con.Close();

          //}


          public void update_numberitem(int name, Int64 number)
          {
              con.Open();
              SqlCommand com = new SqlCommand("update items set current_quantaty=" + number + " where items_id=" + name + "", con);
              com.ExecuteNonQuery();
              con.Close();
          }

          public void insert_invoice2(Int64 amount,Int64 item,Int64 suptotal,int fkid)
          {
              con.Open();
              SqlCommand com = new SqlCommand("insert into invoice_2 values("+amount+",'"+item+"',"+suptotal+","+fkid+")", con);
              com.ExecuteNonQuery();
              con.Close();
          }

          public void select_id(string name,string date,ref int id)
          {
              id = 0;
              con.Open();

              SqlCommand com = new SqlCommand("select max(invoice1_id) from invoice_1 where company_name='" + name + "'and date='"+date+"'", con);
              SqlDataReader dr = com.ExecuteReader();
              if (dr.Read())
              { id = int.Parse(dr[0].ToString()); }
              else
              { id = 0; }
              dr.Close();
              con.Close();
 
          }

          public void select_invoice_info(int id, ref string description,ref Int64 item_num ,ref double unit_value)
          {
              description = ""; unit_value = 0; item_num = 0;
              con.Open();
              SqlCommand com = new SqlCommand("select item_describtion,unit_value,current_quantaty from items where items_id=" + id + "", con);
              SqlDataReader dd = com.ExecuteReader();
              if (dd.Read())
              {
                  description = dd[0].ToString();
                  unit_value = double.Parse(dd[1].ToString());
                  item_num = Int64.Parse(dd[2].ToString());
              }
                 
              else
              { description = "";
              unit_value = 0;
              item_num = 0;
              }
              dd.Close();
              con.Close();
          }

	#endregion




         
    }
}
