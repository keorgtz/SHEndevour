   M S B A M L   `   `   `  ����E  ASHEndevour, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null[2clr-namespace:SHEndevour.ViewModels.Settings.Sales$SHEndevour.ViewModels.Settings.Sales  5	      Q-clr-namespace:SHEndevour.Views.Settings.SalesSHEndevour.Views.Settings.Sales  5
      5    /SHEndevour.Views.Settings.Sales.ConfigurarPagos   5      a ]DevExpress.Xpf.Core.v24.1, Version=24.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aW SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35J 9http://schemas.microsoft.com/winfx/2006/xaml/presentation       5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      a ]DevExpress.Xpf.Grid.v24.1, Version=24.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49af	 bDevExpress.Xpf.Grid.v24.1.Core, Version=24.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49al
 hDevExpress.Xpf.Grid.v24.1.Extensions, Version=24.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a@dxg2http://schemas.devexpress.com/winfx/2008/xaml/grid  	 
 5      e aDevExpress.Xpf.Printing.v24.1, Version=24.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aCdxpr6http://schemas.devexpress.com/winfx/2008/xaml/printing   5      c _MaterialDesignThemes.MahApps, Version=3.1.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962a_ [MaterialDesignThemes.Wpf, Version=5.1.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aHmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes   5      =vm2clr-namespace:SHEndevour.ViewModels.Settings.Sales   5	      ;local-clr-namespace:SHEndevour.Views.Settings.Sales   5
      ���#f1f1f1*  $MaterialDesignThemes.Wpf.ThemeAssist    Theme$  Light=�5   4    � DataContext 5      ;  5SHEndevour.ViewModels.Settings.Sales.PaymentViewModel  5   
   .��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $��* �6   .+�5   
   � $��0��6    � ColumnDefinitions 5      �� 5      $
��auto �6#   �� 5      $��* �6#   .+�5"      (  "MaterialDesignThemes.Wpf.ColorZone  $��10q�6'   .  (MaterialDesignThemes.Wpf.ElevationAssist   	Elevation$	 Dp4=�5#      $}�False��5$         CornerRadius$ 5��5%      
�������   Mode$ Custom=�5'      $
��Left=�5(      .  (MaterialDesignThemes.Wpf.ColorZoneAssist   
Background �#022534.��5+      �� $��0��6    �� Orientation$ 
Horizontal=�6-   .+�5-      �� $��5q�5.      $��0,0,5,0q�6%   
����iA�   MaterialDesignFlatButton#��[  5/   	   ��5-      �� *AddSegmentCommand+.��50      �� $ 
Horizontal=�6%   .+�51      '  !MaterialDesignThemes.Wpf.PackIcon  $��2q�66   	   Kind$		 Add=�6A   �� 52      $��Agregar Pago��6(   53      54      �� 56      $��5q�57      $��0,0,5,0q�6%   
����� �#��[  58   	   ��56      �� *ViewSegmentCommand+.��59      �� $ 
Horizontal=�6%   .+�5:        $��2q�66   $
	 Edit=�6A   �� 5;      $��Examinar Pago��6(   5<      5=      �� 5?      $��5q�5@      $��0,0,5,0q�6%   
���  ��#��[  5A   	   ��5?      �� *DeleteSegmentCommand+.��5B      �� $ 
Horizontal=�6%   .+�5C        $��2q�66   $	 Remove=�6A   �� 5D      $��Eliminar Pago��6(   5E      5F      5H      5I      5M      %  DevExpress.Xpf.Grid.GridControl  5Q   
   -   5        
  Name$
 PaymentsGrid��5Q      $��1��60   $��10q�5S      ) 	 #DevExpress.Xpf.Grid.DataControlBase   SelectionMode$	 Row=�5T         ItemsSource 5R      �� *
Segments+   SelectedItem 5U      �� *SelectedSegment+   View 5V      #	  DevExpress.Xpf.Grid.TableView	  5W       	  	AutoWidth$
 True��6    &
 	  DevExpress.Xpf.Grid.DataViewBase 
  AllowSorting$
 True��61      Columns. 5Z      $  DevExpress.Xpf.Grid.GridColumn  $ 	 DevExpress.Xpf.Grid.ColumnBase   	FieldName$ 
PaymentKey��6   $ 	 DevExpress.Xpf.Grid.BaseColumn   Header)  #DevExpress.Xpf.Core.ObjectConverter$ Cuenta 64      ReadOnly$
 True��6D     5[      $ Descripcion��6   $ Descripcion 65   $
 True��6J     5]      $ CuentaContable��6   $ Cuenta Contable 68   $
 True��6Q     5^      $ ClaveSat��6   $ 	Clave Sat 62   $
 True��6E   5a      5c      5d      