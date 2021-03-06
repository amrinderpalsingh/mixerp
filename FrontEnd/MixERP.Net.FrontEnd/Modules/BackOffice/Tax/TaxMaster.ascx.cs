﻿/********************************************************************************
Copyright (C) Binod Nepal, Mix Open Foundation (http://mixof.org).

This file is part of MixERP.

MixERP is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

MixERP is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with MixERP.  If not, see <http://www.gnu.org/licenses/>.
***********************************************************************************/

using MixERP.Net.FrontEnd.Base;
using MixERP.Net.WebControls.ScrudFactory;
using System;
using System.Reflection;

namespace MixERP.Net.Core.Modules.BackOffice.Tax
{
    public partial class TaxMaster : MixERPUserControl
    {
        public override void OnControlLoad(object sender, EventArgs e)
        {
            using (ScrudForm scrud = new ScrudForm())
            {
                scrud.KeyColumn = "tax_master_id";
                scrud.TableSchema = "core";
                scrud.Table = "tax_master";
                scrud.ViewSchema = "core";
                scrud.View = "tax_master_scrud_view";
                scrud.Text = Resources.Titles.TaxMaster;

                scrud.ResourceAssembly = Assembly.GetAssembly(typeof(TaxMaster));
                this.ScrudPlaceholder.Controls.Add(scrud);
            }
        }
    }
}