<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AdminHomepage.aspx.cs" Inherits="MangAtongsPrototype.ASPX.AdminHompage" %>
<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>  

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

   <div class="container-fluid text-center">
         <br />
        <div class="overflow-hidden text-center text-white" style="background-color: #ffb28f;">
            <div class="col-md-5 p-lg-5 mx-auto" style="padding: 20px 0 20px">
                <h2 class="display-5 fw-normal mons" style="font-weight: 600;">Dashboard</h2>
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-1"></div>

            <div class="col">
                <div class="">
                    <div class="card-body">
                        <div class="row">
                            <div class="card col-12 col-lg-3">
                                <div class="card-body">
                                    <h5 class="card-title"><asp:Label runat="server" ID="UserCount" Text=""></asp:Label></h5>
                                    <h6 class="card-subtitle mb-2 text-muted">Users</h6>
                                </div>
                            </div>
                            <div class="card col-12 col-lg-3">
                                <div class="card-body">
                                    <h5 class="card-title"><asp:Label runat="server" ID="OrderCount" Text=""></asp:Label></h5>
                                    <h6 class="card-subtitle mb-2 text-muted">Total Orders</h6>
                                </div>
                            </div>
                            <div class="card col-12 col-lg-3">
                                <div class="card-body">
                                    <h5 class="card-title"><asp:Label runat="server" ID="POrderCount" Text=""></asp:Label></h5>
                                    <h6 class="card-subtitle mb-2 text-muted">Pending Orders</h6>
                                </div>
                            </div>
                            <div class="card col-12 col-lg-3">
                                <div class="card-body">
                                    <h5 class="card-title"><asp:Label runat="server" ID="SalesCount" Text=""></asp:Label></h5>
                                    <h6 class="card-subtitle mb-2 text-muted">Total Sales</h6>
                                </div>
                            </div>
 
                        </div>

                        <hr />

                        <div class="row">
                            <div class="col-lg-1"></div>
                            <div class="col-12 col-lg-10">
                                <div class="card-body">
                                    <div class="card-title">
                                        <asp:Chart CanResize="true" ID="Sales" runat="server" Height="450px" Width="700px">  
                                            <Titles>  
                                                <asp:Title ShadowOffset="0" Name="Items" Text="" />  
                                            </Titles>  
                                            <Legends>  
                                                <asp:Legend Alignment="Center" Docking="Bottom" IsTextAutoFit="False" Name="Default" LegendStyle="Row" Title="Order Dates" />  
                                            </Legends>  
                                            <Series>  
                                                <asp:Series Name="Earnings" />  
                                            </Series>  
                                            <ChartAreas>  
                                                <asp:ChartArea Name="ChartArea1" BorderWidth="1" />  
                                            </ChartAreas>  
                                        </asp:Chart>
                                    </div>
                                    <h6 class="card-subtitle mb-2 text-muted">Sale Progression</h6>
                                </div>
                            </div>
                            <div class="col-lg-1"></div>
                        </div>

                        <hr />
                        <div class="row">
                            <div class="col-lg-1"></div>
                            <div class="col-12 col-lg-10">
                                <div class="card-body">
                                    <div class="card-title">
                                    
                                        <asp:Chart ID="ProdSalesChartInfo" runat="server" Height="450px" Width="550px">  
                                            <Titles>  
                                                <asp:Title ShadowOffset="0" Name="Items" Text="" />  
                                            </Titles>  
                                            <Legends>  
                                                <asp:Legend Alignment="Center" Docking="Bottom" IsTextAutoFit="False" Name="Default" LegendStyle="Row" Title="Frequency of Orders" />  
                                            </Legends>  
                                            <Series>  
                                                <asp:Series Name="Product ID" />  
                                            </Series>  
                                            <ChartAreas>  
                                                <asp:ChartArea Name="ChartArea1" BorderWidth="1" />  
                                            </ChartAreas>  
                                        </asp:Chart>
                                        

                                    </div>
                                    <h6 class="card-subtitle mb-2 text-muted">Product Comparison</h6>
                                </div>
                            </div>
                            <div class="col-lg-1"></div>                         
                        </div>

                    </div>
                </div>
            </div>
            <div class="col-1">
            </div>

        </div>

    </div>
</asp:Content>
