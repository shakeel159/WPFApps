   M S B A M L   `   `   `  ����E  AWeatherApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:WeatherApp.View.UserControlsWeatherApp.View.UserControls  5      K*clr-namespace:WeatherApp.View.UserControlsWeatherApp.View.UserControls  5      0    *WeatherApp.View.UserControls.BottomControl   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      <local*clr-namespace:WeatherApp.View.UserControls     5      >InfoTab*clr-namespace:WeatherApp.View.UserControls     5      .��5
      �   � ColumnDefinitions  5   
   �� 5      �� 5      �� 5       � RowDefinitions 5   
   �� 5      �� 5      .+�5   
   �� 
�������$��0,0,2,0q�6$   ._�5      �� $��0��6   $�� Today��6(    �� TextAlignment$ Center=�66   $��20(�6M   5      �� 5   
   
�������$��0,0,2,0q�6$   $��0��6>   $��1��6N   5      ,   &WeatherApp.View.UserControls.InfoTexts  5   
   -   5          Name$ infoControl_Today��5         Latitude$ 41.8781Q�67      	Longitude$ -87.6298Q�6J      RequestedDate$  ��6_   $��0��6p   $��1��6�   �� 5   
   
�������$��0,0,2,0q�6$   $��1��6>   $��0��6N   ._�5      �� $��1��6   $��	 Tomorrow��6(   $ Center=�69   $��20(�6P   5      �� 5   
   
�������$��0,0,2,0q�6$   $��1��6>   $��1��6N   ._�5        -   5        $ infoControl_Tomorrow��5       $ 41.8781Q�6>   $ -87.6298Q�6Q   $  ��6f   $��1��6w   $��1��6�   5      �� 5    
   $��2��6   $��	 DayAFter��6$   $ Center=�65   $��20(�6L     5!   
   -   5        $ infoControl_DayAfter��5!      $ 41.8781Q�6:   $ -87.6298Q�6M   $  ��6b   $��2��6s   $��1��6�   5"      5#      