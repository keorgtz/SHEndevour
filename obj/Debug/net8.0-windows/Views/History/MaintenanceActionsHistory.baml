   M S B A M L   `   `   `  ����E  ASHEndevour, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null[2clr-namespace:SHEndevour.ViewModels.Settings.Rooms$SHEndevour.ViewModels.Settings.Rooms  5	   	   C&clr-namespace:SHEndevour.Views.HistorySHEndevour.Views.History  5
   	   8    2SHEndevour.Views.History.MaintenanceActionsHistory   5   	   a ]DevExpress.Xpf.Core.v24.1, Version=24.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aW SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35J 9http://schemas.microsoft.com/winfx/2006/xaml/presentation       5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   c _MaterialDesignThemes.MahApps, Version=3.1.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962a_	 [MaterialDesignThemes.Wpf, Version=5.1.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aHmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  	 5   	   a
 ]DevExpress.Xpf.Grid.v24.1, Version=24.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49af bDevExpress.Xpf.Grid.v24.1.Core, Version=24.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49al hDevExpress.Xpf.Grid.v24.1.Extensions, Version=24.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a@dxg2http://schemas.devexpress.com/winfx/2008/xaml/grid 
   5   	   e aDevExpress.Xpf.Printing.v24.1, Version=24.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aCdxpr6http://schemas.devexpress.com/winfx/2008/xaml/printing   5   	   =vm2clr-namespace:SHEndevour.ViewModels.Settings.Rooms   5	   	   4local&clr-namespace:SHEndevour.Views.History   5
   	     � WindowStartupLocation$  CenterScreen=�5   	    � WindowState$ 	Maximized=�5   	    � WindowStyle$
 None=�5   	   ���#f1f1f1* 	 $MaterialDesignThemes.Wpf.ThemeAssist   Theme$ Light=�5       � Title$0 *Historial de Movimientos de Mantenimientos��5   	   $	��450��6<   $
��1000��6I    � DataContext 5      C   =SHEndevour.ViewModels.Settings.Rooms.RoomMaintenanceViewModel  5   
   .��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $��* �6   .+�5   
   ( 	 "MaterialDesignThemes.Wpf.ColorZone  ���#022534   CornerRadius$ 5��5   #   $��5q�5    #   .��5!      �� .+�5#      � $��0��6    � ColumnDefinitions 5$      �� 5%      $��* �6+   �� 5&      $��* �6+   .+�5)      �� -   5           MaterialDesignFlatButton#��[  5*      $��0��5+   5   $��40��5,      
����� ���5)      0 	 *MaterialDesignThemes.Wpf.PackIconExtension  	   Kind$	 Printer=�
   Size
 255-      �� 5/      -   5        #��[  50      $��1��51   4   $��40��52      
���  ����5/        $	 Close=�
 2553      54      56      57      % 
 DevExpress.Xpf.Grid.GridControl  5:   
   -   5          Name$ MaintenanceHistoryGrid��5:      $��1��6:   $��5q�5<      )  #DevExpress.Xpf.Grid.DataControlBase   ItemsSource 5;      �� *
Historys+   View 5=      # 
 DevExpress.Xpf.Grid.TableView  5>         	AutoWidth$
 True��6    &   DevExpress.Xpf.Grid.DataViewBase   AllowSorting$
 True��61      Columns. 5C      $	 
 DevExpress.Xpf.Grid.GridColumn	  $
  DevExpress.Xpf.Grid.ColumnBase 
  	FieldName$ MaintenanceAction��6   $  DevExpress.Xpf.Grid.BaseColumn   Header)  #DevExpress.Xpf.Core.ObjectConverter$ 
Movimiento 6;    
  ReadOnly$
 True��6O   	  5D      $ MaintenanceActionBy��6   $ Realizado Por 6=   $
 True��6T   	  5E      $ 
ActionDate��6   $ Fecha del Movimiento 65   $
 True��6S   	  5G      $ RoomKey��6   $ Habitación 61   $
 True��6E   	  5H      $ MaintenanceDescription��6   $" Descripcion de Mantenimiento 6@   $
 True��6f   	  5I      $ 	BlockType��6   $ Tipo de Bloqueo 63   $
 True��6L   	  5J      $ 
RoomStatus��6   $ Razon del Bloqueo 64   $
 True��6O   	  5K      $ CreatedbyUser��6   $ 
Creado por 67   $
 True��6K   	  5L      $ CreatedOnDate��6   $ 	Creado El 67   $
 True��6J   5P      5R      5S      