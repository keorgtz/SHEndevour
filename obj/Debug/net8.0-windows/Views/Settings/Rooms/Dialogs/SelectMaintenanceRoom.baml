   M S B A M L   `   `   `  ����E  ASHEndevour, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null[2clr-namespace:SHEndevour.ViewModels.Settings.Rooms$SHEndevour.ViewModels.Settings.Rooms  5	   	   a5clr-namespace:SHEndevour.Views.Settings.Rooms.Dialogs'SHEndevour.Views.Settings.Rooms.Dialogs  5
   	   C    =SHEndevour.Views.Settings.Rooms.Dialogs.SelectMaintenanceRoom   5   	   a ]DevExpress.Xpf.Core.v24.1, Version=24.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aW SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35J 9http://schemas.microsoft.com/winfx/2006/xaml/presentation       5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   c _MaterialDesignThemes.MahApps, Version=3.1.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962a_	 [MaterialDesignThemes.Wpf, Version=5.1.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aHmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  	 5   	   a
 ]DevExpress.Xpf.Grid.v24.1, Version=24.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49af bDevExpress.Xpf.Grid.v24.1.Core, Version=24.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49al hDevExpress.Xpf.Grid.v24.1.Extensions, Version=24.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a@dxg2http://schemas.devexpress.com/winfx/2008/xaml/grid 
   5   	   e aDevExpress.Xpf.Printing.v24.1, Version=24.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aCdxpr6http://schemas.devexpress.com/winfx/2008/xaml/printing   5   	   =vm2clr-namespace:SHEndevour.ViewModels.Settings.Rooms   5	   	   Clocal5clr-namespace:SHEndevour.Views.Settings.Rooms.Dialogs   5
   	   ���#f1f1f1  � WindowStartupLocation$  CenterScreen=�5       � Title$ SelectMaintenanceRoom��5   	   $	��350��6'   $	��500��64    � DataContext 5      B   <SHEndevour.ViewModels.Settings.Rooms.RoomManagementViewModel  5   
   .��5      �  � RowDefinitions 5   
   �� 5      �� 5      $
��auto �6   .+�5   
   % 
 DevExpress.Xpf.Grid.GridControl  -   5          Name$ MaintenanceRoomsGrid��5      $��0��68   $��10q�5       )  #DevExpress.Xpf.Grid.DataControlBase   ItemsSource 5      �� *Notblockeds+   SelectedItem 5!      �� *SelectedRoom+   View 5"      # 
 DevExpress.Xpf.Grid.TableView  5#         	AutoWidth$
 True��6    &   DevExpress.Xpf.Grid.DataViewBase	   AllowSorting$
	 True��61   
   Columns.
 5&      $ 
 DevExpress.Xpf.Grid.GridColumn  $  DevExpress.Xpf.Grid.ColumnBase   	FieldName$ RoomKey��6   $  DevExpress.Xpf.Grid.BaseColumn   Header)	  #DevExpress.Xpf.Core.ObjectConverter$ Habitación	 61      ReadOnly$
 True��6E     5'      $ 
RoomStatus��6   $ Estado	 64   $
 True��6D     5(      $ RoomType.RoomTypeKey��6   $ Clave de Tipo	 6>   $
 True��6U     5)      $ RoomType.Description��6   $
 Tipo	 6>   $
 True��6L   5*      �� 5,   
    �� Orientation$ 
Horizontal=�6   $��1��6.   $��Right=�6;   $��5q�6W   .+�5-      �� -   5        $��Cancelar��5-       �� IsCancel$
 True��6(   
���  ��   MaterialDesignFlatButton#��[  6I   6{   �� 5.      -   5        $��Aceptar��5.       �� 	IsDefault$
 True��6'   #��[  68   6j   5/      52      53      