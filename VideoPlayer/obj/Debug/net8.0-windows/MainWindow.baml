   M S B A M L   `   `   `  ����  VideoPlayer    VideoPlayer.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -   5          � Title$  Video player��5   	   $	��660��6   $	��640��6+    � 
ResizeMode$ 	CanResize=�5   	    � WindowStartupLocation$ CenterScreen=�6    .��5
      � 
������  � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $
��Auto �6   �� 5      $
��0.2* �6   �� 5      $
��0.2* �6   �� 5      $
��0.2* �6   �� 5      $
��0.2* �6   �� 5      $
��0.2* �6   .+�5   
   r� -   5        $��media��5   $   $��0��6    r� LoadedBehavior$ Manual=�61    r� Stretch$ Uniform=�6I   �� 5   
   -   5        $��audioTrackPanel��5   G   $��2��6    �� Orientation$ 
Horizontal=�6"   $��10q�6;   .+�5      �� $��Audio track:��6   $��Center=�6+   6H   �� 5      -   5        $��fileName��5   #   $
��None��6   $��Center=�63   6P   5      � 5   
   $��3��6   $��10q�6    � ColumnDefinitions 5       �� 5!      $��* �6#   �� 5#      $
��Auto �6#   .+�5'      �� $ 
Horizontal=�6   .+�5(      �� -   5        $��cmdPlay��5(   0   $��75��6   $��20��6$   .��6U   Play6[   �� 5)      -   5        $��cmdStop��5)   0   $��75��6   $��20��6$   .��6U   Stop6[   �� 5*      -   5        $��cmdPause��5*   0   $��75��6   $��20��6$   .��6W   Pause6^   �� 5+      -   5        $��cmdLoad��5+   0   $��75��6   $��20��6$   $��10,0,0,0q�6?   .��6g   Load6m   5,      �� 5.      -	   5        $��btnToggleFullscreen��5.   -   $	��100��6   $��20��6!   $��
Fullscreen��6H   $��10,0,0,0q�6]   $��1��6�   5/      �� 52   
   -
   5        $��volumePanel��52   E   $��4��6   $ Vertical=�6"   $��10q�69   .+�53      �� $��Volume:��6   $��Center=�6&   6C   �� 54      -   5        $��volumeSlider��54       � Minimum$ 0Q�6)   	 � Maximum$	 1Q�65   
 � Value$	
 0.5Q�6A   $��Stretch=�6M   $��0q�6k   6v   55      �� 58   
   -   5        $��balancePanel��58   E   $��5��6   $ Vertical=�6"   $��10q�69   .+�59      �� $��Balance:��6   $��Center=�6'   6D   �� 5:      -   5        $��balanceSlider��5:      $ -1Q�6*   $	 1Q�67   $
 0Q�6C   $��Stretch=�6M   $��0q�6k   6v   5;      �� 5>   
   -   5        $��positionPanel��5>   E   $��6��6   $ Vertical=�6"   $��10q�69   .+�5?      �� $��	Position:��6   $��Center=�6(   6E   �� 5@      -   5        $��positionSlider��5@      $
 1Q�6+   $	 3Q�65   $ 1Q�6A    � SmallChange$
 0.25Q�6M   $��Stretch=�6`   $��0q�6~   6�   5A      5B      5C      