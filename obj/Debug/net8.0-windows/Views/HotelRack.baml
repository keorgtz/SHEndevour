   M S B A M L   `   `   `  ����E  ASHEndevour, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:SHEndevour.ViewModelsSHEndevour.ViewModels  5      3clr-namespace:SHEndevour.ViewsSHEndevour.Views  5      'clr-namespace:SHEndevour
SHEndevour  5	      'clr-namespace:SHEndevour
SHEndevour  5
           SHEndevour.Views.HotelRack   5      a ]DevExpress.Xpf.Core.v24.1, Version=24.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aW SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35J 9http://schemas.microsoft.com/winfx/2006/xaml/presentation       5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      c _MaterialDesignThemes.MahApps, Version=3.1.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962a_	 [MaterialDesignThemes.Wpf, Version=5.1.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aHmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  	 5      .vm#clr-namespace:SHEndevour.ViewModels  	 5      ,localclr-namespace:SHEndevour.Views  	 5      )RootRackclr-namespace:SHEndevour  	 5	      *	NullaEnumclr-namespace:SHEndevour  	 5
      ���#f1f1f1  � DataContext  5      .   (SHEndevour.ViewModels.RackHotelViewModel  5   
    � 	Resources 5      +   %SHEndevour.RoomStatusToColorConverter   RoomStatusToColorConverter&    SHEndevour.NullableEnumConverter  NullableEnumConverter��%:   &	        &	        5   
   6.     5   
   6*   5      .��5      �  � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $
��auto �6   .+�5!   
   � $��0��6    � RowDefinitions 5#      �� 5$      $
��auto �6    �� 5%      $
��auto �6    �� 5&      $��* �6    �� 5'      $
��auto �6    .+�5*      ( 	 "MaterialDesignThemes.Wpf.ColorZone  $��0��6'   $��5q�5+   '      CornerRadius$ 10��5,   '   ���#013d5a. 	 (MaterialDesignThemes.Wpf.ElevationAssist   	Elevation$	 Dp1=�5.   '   $��Stretch=�5/   '   $��Stretch=�50   '   .��51      �� .+�53      �� $��Rack de Habitaciones��6    $��Center=�54       $��
Montserrat)�55       $��5q�56       
�������$
��Bold"�57       $��20(�58       5=      5>      � 5@      $��1��6   $��5,0,5,0q�6(    5B      �� 5C      $��* �6/   �� 5D      $��* �6/   �� 5E      $��* �6/   �� 5F      $��* �6/   �� 5G      $��* �6/   �� 5H      $��* �6/   .+�5M      �� $��0��6%   $��5q�65    �� Orientation$ 
Horizontal=�6@   $��Center=�6Y   .+�5N      �� $��⚫ Vacias Limpias��6(   $��
Montserrat)�6@   $
��Bold"�6X   
��� � �6j   �� 5O      $��5,0,0,0q�6E   $��
Montserrat)�6V   $
��Bold"�6n   
��� � ���6(   �� *VLRoomCount+6�   5P      �� 5R      $��1��6%   $��5q�65   $ 
Horizontal=�6@   $��Center=�6Y   .+�5S      �� $��⚫ Vacias Sucias��6(   $��
Montserrat)�6?   $
��Bold"�6W   
��� ���6i   �� 5T      $��5,0,0,0q�6E   $��
Montserrat)�6V   $
��Bold"�6n   
��� �����6(   �� *VSRoomCount+6�   5U      �� 5W      $��2��6%   $��5q�65   $ 
Horizontal=�6@   $��Center=�6Y   .+�5X      �� $��⚫ Ocupadas Limpias��6(   $��
Montserrat)�6B   $
��Bold"�6Z   ���#00589B6l   �� 5Y      $��5,0,0,0q�6E   $��
Montserrat)�6V   $
��Bold"�6n   ���#00589B��6(   �� *OLRoomCount+6�   5Z      �� 5\      $��3��6%   $��5q�65   $ 
Horizontal=�6@   $��Center=�6Y   .+�5]      �� $��⚫ Ocupadas Sucias��6(   $��
Montserrat)�6A   $
��Bold"�6Y   
����� �6k   �� 5^      $��5,0,0,0q�6E   $��
Montserrat)�6V   $
��Bold"�6n   
����� ���6(   �� *OSRoomCount+6�   5_      �� 5a      $��4��6%   $��5q�65   $ 
Horizontal=�6@   $��Center=�6Y   .+�5b      �� $��⚫ En Mantenimiento��6(   $��
Montserrat)�6B   $
��Bold"�6Z   
����p��6l   �� 5c      $��5,0,0,0q�6D   $��
Montserrat)�6U   $
��Bold"�6m   
����p����6(   �� *
MRoomCount+6   5d      �� 5f      $��5��6%   $��5q�65   $ 
Horizontal=�6@   $��Center=�6Y   .+�5g      �� $��⚫ Bloqueadas��6(   $��
Montserrat)�6<   $
��Bold"�6T   
���� ��6f   �� 5h      $��5,0,0,0q�6D   $��
Montserrat)�6U   $
��Bold"�6m   
���� ����6(   �� *
BRoomCount+6   5i      5l      �� 5n      $��2��6   $
��Auto=�5o        MaterialDesignScrollViewer#��[ 5p      . 	 (MaterialDesignThemes.Wpf.ScrollBarAssist   ThumbCornerRadius$ 5��5q         ButtonsVisibility$ 	Collapsed=�5r      $��Disabled=�5s      .��5v        $��2��6'   ���#FFFFFF$��Stretch=�5x   '   $��Stretch=�5y   '   $��5q�5z   '   $ 2��5{   '   $
��Auto=�5|   '   $	 Dp2=�5}   '   .��5�      �� .+�5�      �� ��6#   �� *	RoomsView+��5�      �� 5�      .R�5�   "   A� 	 A� Columns$	 8��6.   5�      ��5�      �� 5�      .R�5�   "   �� $��10q�6)   ._�5�   &     $	 Dp2=�6?   $
��auto��5�   2   $��60��6?   $��5q�6K   $ 5��5�   2   * 	 $MaterialDesignThemes.Wpf.ThemeAssist
   Theme$
 Light=�5�   2   ��5�   2   �� *
RoomStatus+ �� 	Converter# [  ��5�   2   �� *
RoomStatus+# [   �� ConverterParameter$ 
Foreground��.��5�   *   �� $��Center=�65   $��Center=�6R   .+�5�   .   �� $��Center=�5�   '   $
��Bold"�5�   '   $��16(�69   $��
Montserrat)�6G   ��5�   8   �� *	RoomKey+5�   G   �� 5�   .   $��Center=�5�   '   $��DemiBold"�5�   '   $��16(�6=   $��
Montserrat)�6K   ��5�   8   �� *RoomType.RoomTypeKey+5�   K   5�   +   5�   '   5�   #   5�      5�      5�      5�      5�        5�      $��3��6'   ���#013D5A$��5q�5�   '   $ 2��5�   '   $��Stretch=�5�   '   $��Stretch=�5�   '   .��5�      �� $��	10,5,10,5q�6   .+�5�      �� $ 
Horizontal=�6!   .+�5�      �� $	��150��5�   #    " MaterialDesignOutlinedComboBox#��[ 6/   $��5q�5�   #   
�������) 	 #MaterialDesignThemes.Wpf.HintAssist   
Foreground
 �����   
IsFloating$ False��5�   #      Hint$ Filtros��5�   #   $��16(�6L   $

 Dark=�5�   #   $
��Left=�5�   #   $��10,5,0,5q�5�   #   ��5�   #   �� *RoomStatusOptions+ �� SelectedItem 5�   #   �� *RoomStatusFilter+ �� Mode$ TwoWay=�5�   #   �� 5�      $��35��6[   $
��Left=�5�      $��0q�68   $��5q�5�      
���  ��  MaterialDesignFlatButton#��[ 5�      ��5�   !   0	 	 *MaterialDesignThemes.Wpf.PackIconExtension	   	  Kind$ CloseBox=� 	  Size 30��5�      �� *ClearFiltersCommand+5�      5�      5�      5�      5�      5�      