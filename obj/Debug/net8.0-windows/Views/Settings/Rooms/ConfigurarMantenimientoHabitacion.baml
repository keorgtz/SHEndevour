   M S B A M L   `   `   `  ����E  ASHEndevour, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullQ-clr-namespace:SHEndevour.Views.Settings.RoomsSHEndevour.Views.Settings.Rooms  5      [2clr-namespace:SHEndevour.ViewModels.Settings.Rooms$SHEndevour.ViewModels.Settings.Rooms  5
      'clr-namespace:SHEndevour
SHEndevour  5      G    ASHEndevour.Views.Settings.Rooms.ConfigurarMantenimientoHabitacion   5      a ]DevExpress.Xpf.Core.v24.1, Version=24.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aW SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35J 9http://schemas.microsoft.com/winfx/2006/xaml/presentation       R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ?local-clr-namespace:SHEndevour.Views.Settings.Rooms     5      c _MaterialDesignThemes.MahApps, Version=3.1.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962a_	 [MaterialDesignThemes.Wpf, Version=5.1.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aHmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  	 5      a
 ]DevExpress.Xpf.Grid.v24.1, Version=24.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49af bDevExpress.Xpf.Grid.v24.1.Core, Version=24.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49al hDevExpress.Xpf.Grid.v24.1.Extensions, Version=24.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a@dxg2http://schemas.devexpress.com/winfx/2008/xaml/grid 
   5      e aDevExpress.Xpf.Printing.v24.1, Version=24.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aCdxpr6http://schemas.devexpress.com/winfx/2008/xaml/printing   5	      =vm2clr-namespace:SHEndevour.ViewModels.Settings.Rooms   5
      )NullBoolclr-namespace:SHEndevour   5      ���#f1f1f1* 	 $MaterialDesignThemes.Wpf.ThemeAssist    Theme$  Light=�5       � DataContext 5      C   =SHEndevour.ViewModels.Settings.Rooms.RoomMaintenanceViewModel  5   
    � 	Resources 5      $   SHEndevour.NullToBoolConverter   NullToBoolConverter��%   &	          5   
   6'   5      .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5#   
   ( 	 "MaterialDesignThemes.Wpf.ColorZone  $��10q�6#   . 	 (MaterialDesignThemes.Wpf.ElevationAssist   	Elevation$	 Dp4=�5$   #   $}�False��5%   #      CornerRadius$ 5��5&   #   $��Stretch=�5'   #   $��Stretch=�5(   #   $��40��5)   #   
�������   Mode$ Custom=�5+   #   . 	 (MaterialDesignThemes.Wpf.ColorZoneAssist   
Background �#001b48.��5.      � $��0��6    � ColumnDefinitions 5/      �� 50      $��* �6'   �� 51      $��* �6'   �� 52      $��* �6'   �� 53      $��* �6'   �� 54      $��* �6'   .+�58      �� $��0��6   $��7q�59      $��0,0,5,0q�6%   
����iA�  MaterialDesignFlatButton#��[ 5:      ��5;      �� *AddMaintenanceCommand+.��5<      �� 	 �� Orientation$	 
Horizontal=�6!   .+�5=      ' 	 !MaterialDesignThemes.Wpf.PackIcon  $��2q�62   
   Kind$

 Plus=�6=   �� 5>      $��Agregar��6$   5?      5@      �� 5C      $��1��6   $��7q�5D      $��0,0,5,0q�6%   
����� �#��[ 5E      ��5F      �� *ViewMaintenanceCommand+{�5G      �� *SelectedMaintenance+ �� 	Converter# [  .��5H      �� $	 
Horizontal=�6!   .+�5I        $��2q�62   $

 Edit=�6=   �� 5J      $��Editar��6$   5K      5L      �� 5O      $��2��6   $��7q�5P      $��0,0,5,0q�6%   
���  ��#��[ 5Q      ��5R      �� *ReleaseMaintenanceCommand+{�5S      �� *SelectedMaintenance+# [  .��5T      �� $	 
Horizontal=�6!   .+�5U        $��2q�62   $
 Delete=�6=   �� 5V      $��Liberar��6$   5W      5X      �� 5[      -   5        $��3��5[      $��7q�5\      $��0,0,5,0q�6%   
��� ���#��[ 5^      .��5_      �� $	 
Horizontal=�6!   .+�5`        $��2q�62   $
 History=�6=   �� 5a      $��Históricos��6$   5b      5c      �� 5e      -   5        $��4��5e      $��7q�5f      $��0,0,5,0q�6%   
��� � �#��[ 5g      .��5i      �� $	 
Horizontal=�6!   .+�5j        $��2q�62   $
 Printer=�6=   �� 5k      $��Imprimir��6$   5l      5m      5q      5r      % 
 DevExpress.Xpf.Grid.GridControl  5u   
   -   5          Name$ MaintenanceRoomsGrid��5u      $��1��68   $��10q�5w      )	  #DevExpress.Xpf.Grid.DataControlBase 	  SelectionMode$	 Row=�5x       	  ItemsSource 5v      �� *Maintenances+ 	  SelectedItem 5y      �� *SelectedMaintenance+   View 5z      #
 
 DevExpress.Xpf.Grid.TableView
  5{       
  	AutoWidth$
 True��6    &   DevExpress.Xpf.Grid.DataViewBase   AllowSorting$
 True��61      Columns. 5~      $ 
 DevExpress.Xpf.Grid.GridColumn  $  DevExpress.Xpf.Grid.ColumnBase   	FieldName$ RoomKey��6   $  DevExpress.Xpf.Grid.BaseColumn   Header)  #DevExpress.Xpf.Core.ObjectConverter$ Habitación 61      ReadOnly$
 True��6E     5      $ 
RoomStatus��6   $ Razon del Bloqueo 64   $
 True��6O     5�      $ CauseDescription��6   $ Descripción 6:   $
 True��6O     5�      $ 	BlockType��6   $ Tipo de Bloqueo 63   $
 True��6L     5�      $ EndDate��6   $ Fecha Limite 61   $
 True��6G   5�      5�      5�      