<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Intern_Project_Employee_Management.WebForm1" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Employee Management & Training Info</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />
    <style>
        .feature-card {
            border: 1px solid #e5e7eb;
            border-radius: 8px;
            box-shadow: 0 4px 12px rgba(0,0,0,0.03);
            border-left: 4px solid #06b6d4;
            height: 100%;
            background-color: #ffffff;
        }
        .table-responsive {
            overflow-x: auto;
        }
    </style>
</head>
<body class="bg-light">
    <form id="form1" runat="server">
        <div class="container py-5">

            <div class="text-center mb-5">
                <h2 class="fw-bold text-dark">Why Choose Our CBAP Training for Certification Success?</h2>
                <p class="text-muted fs-6">Learn about the key features and elements of our CBAP Course. Also know about the eligibility criteria and benefits of CBAP.</p>
            </div>

            <div class="row g-4 mb-5">
                <div class="col-12 col-md-6 col-lg-4">
                    <div class="p-4 feature-card">
                        <h5 class="fw-bold mb-3 text-dark">Complete BABOK v3 Coverage</h5>
                        <p class="text-muted mb-0 small">Live Online training to cover BABOK v3 in depth by CBAP certified Professionals (35 hrs PD approved).</p>
                    </div>
                </div>
                <div class="col-12 col-md-6 col-lg-4">
                    <div class="p-4 feature-card">
                        <h5 class="fw-bold mb-3 text-dark">Workshop - Solving Scenario based Questions</h5>
                        <p class="text-muted mb-0 small">Dedicated Workshops to help you learn the tricks of answering Scenario based questions.</p>
                    </div>
                </div>
                <div class="col-12 col-md-6 col-lg-4">
                    <div class="p-4 feature-card">
                        <h5 class="fw-bold mb-3 text-dark">Workshop - Solving Case-Study based Questions</h5>
                        <p class="text-muted mb-0 small">Additional Workshops to help you learn optimized way to answering Case-study based questions.</p>
                    </div>
                </div>
                <div class="col-12 col-md-6 col-lg-4">
                    <div class="p-4 feature-card">
                        <h5 class="fw-bold mb-3 text-dark">Doubt Clearing Sessions</h5>
                        <p class="text-muted mb-0 small">Get your questions answered in special sessions. Leave nothing to chance.</p>
                    </div>
                </div>
                <div class="col-12 col-md-6 col-lg-4">
                    <div class="p-4 feature-card">
                        <h5 class="fw-bold mb-3 text-dark">Repeat Sessions, at no cost</h5>
                        <p class="text-muted mb-0 small">You can repeat any session or full course any time. A Techcanvass Alumni benefit, No Questions Asked.</p>
                    </div>
                </div>
                <div class="col-12 col-md-6 col-lg-4">
                    <div class="p-4 feature-card">
                        <h5 class="fw-bold mb-3 text-dark">CBAP Study Material</h5>
                        <ul class="text-muted ps-3 mb-0 small row">
                            <div class="col-6">
                                <li>BABOK Revision Guide</li>
                                <li>Mind Maps</li>
                                <li>Flashcards</li>
                            </div>
                            <div class="col-6">
                                <li>Question Bank (1200 Q)</li>
                                <li>Cheat Sheets</li>
                                <li>Trainer PPTs</li>
                            </div>
                        </ul>
                    </div>
                </div>
            </div>

            <hr class="my-5 opacity-25" />

            <div class="card shadow-sm border-0 mb-5">
                <div class="card-header bg-dark text-white p-3">
                    <h5 class="mb-0 fw-semibold">Employee & Department Management Form</h5>
                </div>
                <div class="card-body p-4">
                    <div class="row g-3 mb-4">
                        <div class="col-12 col-md-4">
                            <label class="form-label fw-bold text-secondary small">ID (Search/Update/Delete)</label>
                            <asp:TextBox ID="txtid" runat="server" CssClass="form-control" placeholder="ID auto-loads on Grid selection"></asp:TextBox>
                        </div>
                        <div class="col-12 col-md-8">
                            <label class="form-label fw-bold text-secondary small">Employee Name <span class="text-danger">*</span></label>
                            <asp:TextBox ID="txtName" runat="server" CssClass="form-control" placeholder="Enter full name"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                ControlToValidate="txtName" Display="Dynamic" ErrorMessage="Name is required" ForeColor="Red" CssClass="small d-block mt-1" ValidationGroup="vgEmp">
                            </asp:RequiredFieldValidator>
                        </div>
                        <div class="col-12 col-md-4">
                            <label class="form-label fw-bold text-secondary small">Age <span class="text-danger">*</span></label>
                            <asp:TextBox ID="txtAge" runat="server" CssClass="form-control" TextMode="Number" placeholder="Age (18-70)"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                ControlToValidate="txtAge" Display="Dynamic" ErrorMessage="Age is required" ForeColor="Red" CssClass="small d-block mt-1" ValidationGroup="vgEmp">
                            </asp:RequiredFieldValidator>
                            <asp:RangeValidator ID="RangeValidator1" runat="server" 
                                ControlToValidate="txtAge" Display="Dynamic" ErrorMessage="Age must be 18-70" ForeColor="Red" CssClass="small d-block mt-1" 
                                MaximumValue="70" MinimumValue="18" Type="Integer" ValidationGroup="vgEmp">
                            </asp:RangeValidator>
                        </div>
                        <div class="col-12 col-md-4">
                            <label class="form-label fw-bold text-secondary small">Salary <span class="text-danger">*</span></label>
                            <asp:TextBox ID="txtSalary" runat="server" CssClass="form-control" placeholder="Monthly Salary"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                ControlToValidate="txtSalary" Display="Dynamic" ErrorMessage="Salary is required" ForeColor="Red" CssClass="small d-block mt-1" ValidationGroup="vgEmp">
                            </asp:RequiredFieldValidator>
                        </div>
                        <div class="col-12 col-md-4">
                            <label class="form-label fw-bold text-secondary small">Department Name <span class="text-danger">*</span></label>
                            <asp:TextBox ID="txtDept" runat="server" CssClass="form-control" placeholder="e.g. Technology, HR"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                                ControlToValidate="txtDept" Display="Dynamic" ErrorMessage="Department is required" ForeColor="Red" CssClass="small d-block mt-1" ValidationGroup="vgEmp">
                            </asp:RequiredFieldValidator>
                        </div>
                    </div>

                    <div class="d-flex flex-wrap gap-2">
                        <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="ADD RECORD" CssClass="btn btn-success px-4" ValidationGroup="vgEmp" />
                        <asp:Button ID="btnUpdate" runat="server" OnClick="btnUpdate_Click" Text="UPDATE" CssClass="btn btn-warning px-4 text-white" ValidationGroup="vgEmp" />
                        <asp:Button ID="btnDelete" runat="server" OnClick="btnDelete_Click" Text="DELETE" CssClass="btn btn-danger px-4" OnClientClick="return confirm('Are you sure you want to delete this record?');" CausesValidation="false" />
                        <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" Text="SEARCH BY ID" CssClass="btn btn-secondary px-4" CausesValidation="false" />
                    </div>

                    <div class="mt-3">
                        <asp:Label ID="lblMsg" runat="server" Font-Bold="True" CssClass="fs-6"></asp:Label>
                    </div>
                </div>
            </div>

            <div class="card shadow-sm border-0">
                <div class="card-header bg-dark text-white p-3">
                    <h5 class="mb-0 fw-semibold">Registered Records (Click 'Select' to Fill Form)</h5>
                </div>
                <div class="card-body p-0">
                    <div class="table-responsive">
                        <asp:GridView ID="GridView1" runat="server" Width="100%" 
                            CssClass="table table-striped table-hover mb-0 align-middle text-center" GridLines="None"
                            AutoGenerateSelectButton="True" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                            <SelectedRowStyle BackColor="#e2e8f0" Font-Bold="true" />
                        </asp:GridView>
                    </div>
                </div>
            </div>

        </div>
    </form>
</body>
</html>