<% @Page Language="C#" AutoEventWireup="true" CodeFile="GUI.aspx.cs" Inherits="Default2" %>
<% @Import Namespace="LUProj2" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Animal Shelter</title>
</head>
<body runat="server">
    
    <%
        if (Request.QueryString["CRUD"] == "create")
        {                            
            AnimalAccess.Create(Request["breed_create"], Request["weight_create"], Request["age_create"]);          
        }

        if (Request.QueryString["CRUD"] == "delete")
        {
            AnimalAccess.Delete(Request.QueryString["id"]);
        }

        if (Request.QueryString["CRUD"] == "update")
        {
            AnimalAccess.Update(Request.QueryString["id"], Request.Form["breed_content" + Request.QueryString["id"]], Request.Form["weight_content" + Request.QueryString["id"]], Request.Form["age_content" + Request.QueryString["id"]]);
        }
        
        
    %>  

    <form id="table_form" action="GUI.aspx?CRUD=delete" runat="server" method="POST">    
       
        <div>
            <%
                List<Animal> temp_list = AnimalAccess.Read();

                Response.Write("<table border= 1 style= width:50% >");
                Response.Write("<tr><th>ID</th><th>Breed</th><th>Weight</th><th>Age</th></tr>");

                for (int i = 0; i < temp_list.Count; i++)
                {
                    Response.Write(String.Format("<tr><td>{0}</td><td><input type= text value={1} name= breed_content{0} /></td><td><input type=text value={2} name= weight_content{0} /></td><td><input type=text value={3} name= age_content{0} /></td><td><input type= submit formaction=\"GUI.aspx?CRUD=delete&id={0}\" value= Delete /><input type= submit formaction=\"GUI.aspx?CRUD=update&id={0}\" value= Edit /></td></tr>",
                        temp_list[i].Id, temp_list[i].Breed, temp_list[i].Weight, temp_list[i].Age));
                }
                
                Response.Write("</table>");
                
                %>
        </div>  
               
        <table>
            <tr>
                <td><input type="text" name="breed_create"/></td>
                <td><input type="text" name="weight_create"/> </td>
                <td><input type="text" name="age_create"/></td>
                <td><input type="submit" formaction="GUI.aspx?CRUD=create" value="Create"/></td>
            </tr>
        </table>

    </form>         
            
</body>
</html>
