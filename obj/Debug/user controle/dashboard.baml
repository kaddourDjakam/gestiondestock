   M S B A M L   `   `   `  ????F  Bappswindows, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:appswindows.user_controleappswindows.user_controle  5      U QLiveCharts.Wpf, Version=0.9.7.0, Culture=neutral, PublicKeyToken=0bc1f845d1ebb8dfG4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.WpfLiveCharts.Wpf 5	      )    #appswindows.user_controle.dashboard   5      ^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      9local'clr-namespace:appswindows.user_controle     5      b ^MaterialDesignThemes.Wpf, Version=3.2.0.1979, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      >dxc4http://schemas.devexpress.com/winfx/2008/xaml/charts  5      >Wpf4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.Wpf  5	      -   5        $??Stretch=?5      $??Stretch=?6,   .??5      ? $
??1088??6     ? ColumnDefinitions  5   
   ?? 5      $
??auto ?6   ?? 5      $
??auto ?6   ?? 5      $
??auto ?6   ?? 5      $
??auto ?6   ?? 5      $??* ?6    ? RowDefinitions 5   
   ?? 5      $
??auto ?6   ?? 5      $
??auto ?6   ?? 5      $
??auto ?6   ?? 5      $
??auto ?6   ?? 5      $??* ?6   .+?5   
   ? $??10,35,198,15q?6   $??4??6%   .+?5      ?? 
???????$??	0,211,0,0q?6(   $??Center=?6;   $	??352??6X   $	??305??6d   $	??Top=?6q   ._?5         LiveCharts.Wpf.PieChart  -   5          Name$ prchart1??5        $??	0,201,0,0q?62   5!      5"      ? 5#   
   $??372,230,0,53q?6   $??4??6%   $??5??62    5$      ?? 5%      $
??auto ?6    ?? 5&      $??* ?6      5(      ?? 5)      $
??auto ?6#   ?? 5*      $??* ?6#   .+?5,      &   System.Windows.Controls.DataGrid  -   5          Name$ 	data_vent??5,      $??Disabled=?6*      AutoGenerateColumns .  $??7,17,0,0q?6}   
???????$??2??6?   $??2??6?      Columns 5-      0  *System.Windows.Controls.DataGridTextColumn  5.      ,  &System.Windows.Controls.DataGridColumn   Header$ Date ??6)      Width5  /System.Windows.Controls.DataGridLengthConverter$	 100 68   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6D   ?? *
date_vente+	 ?? Mode$	 OneWay=?  5/      $ quantity??6*   $	 100 6<    6H   ?? *qentity_vente+$	 OneWay=?  50      $ produit??6)   $	 100 6:    6F   ?? *nom_produit+$	 OneWay=?  51      $ client??6)   $	 105 69    6E   ?? *
nom_client+$	 OneWay=?  52      $ emplyee??6)   $	 100 6:    6F   ?? *	login_emp+$	 OneWay=?  53      $ 
prix vente??6*   $	 120 6>    6J   ?? *
prix_vente+$	 OneWay=?56      57      ? 58   
   $??0,10,198,375q?6   $??Right=?6%   $	??362??6A   $??5??6M   .+?59      ?? 
???????$	??219??6(   $??Center=?65   $??Right=?6P   $	??351??6l   ._?5:      ? -   5        .+?5;      ?? $??152,10,10,150q?6    $??20(?67   $
??Bold"?6E   $??Microsoft YaHei UI)?6W   
 ?? TextAlignment$
 Center=?6w    J? Opacity$	 0.4Q?6?   ??6?   Z? ?? 6?   $?Emplyee??6?   ?? 6?   ?? 6?   6?   ?? 5<       ?? CornerRadius$ 80??6   $??10,10,216,77q?60   ??5=      ?? 5>      -   5        	emplyeess?? ?? ImageSource$, &/appswindows;component/Img/profile.png??5>   <    j? Stretch$ UniformToFill=?6q   5@      ?? 5A      -   5         ??Name$ nmbrprod??5A       $??112233??62   $??36,155,257,17q?6@   $
??Bold"?6W   $??Microsoft YaHei UI)?6i   $	 0.4Q?6?   $??11(?6?   '  !MaterialDesignThemes.Wpf.PackIcon  5B         Kind$ ShoppingCart=?6/   $??31??6C   $??	5,155,0,0q?6N   ???	#FFFF962D J? RenderTransformOrigin$ 0.698,0.615&?6x   $??16??6?   $	 0.4Q?6?   ?? 5C      -   5        $ catigo??5C   !   $??	catigorie??62   $??254,151,15,17q?6C   $??Microsoft YaHei UI)?6Z   $	 0.4Q?6z   $??14(?6?   ?? 5D      -   5        $
 xemp??5D       $??112233??6.   $??146,154,139,18q?6<   $
??Bold"?6T   $??Microsoft YaHei UI)?6f   $	 0.4Q?6?   $??11(?6?     5E      $
 Cash=?6/   $??31??6;   $??115,151,0,0q?6F   ???	#FF2C4B1A$ 0.698,0.615&?6r   $??20??6?   $	 0.4Q?6?     5F      $ 
Typewriter=?6/   $??31??6A   $??223,155,0,0q?6L   ???	#FF0046FF$ 0.698,0.615&?6x   $??16??6?   $	 0.4Q?6?   ?? 5G      -	   5        $ id??5G       $??198,55,0,105q?6,   $
??Bold"?6B   $??Microsoft YaHei UI)?6T   $	 0.4Q?6t   $??Id??6?   $??14(?6?   ?? 5H      -
   5        $
 name??5H       $??198,88,0,78q?6/   $??14(?6D   $
??Bold"?6R   $??Microsoft YaHei UI)?6d   $	 0.4Q?6?   ?? 6?   $
?Name??6?   ?? 6?   ?? 6?   ?? 6?   ?? 6?   6?     5I      $ 	UserBadge=?6/   $??31??6@   $??
162,50,0,0q?6K   ???	#FF131313$ 0.698,0.615&?6v   $??27??6?   $	 0.4Q?6?     5J      $
 User=?6/   $??31??6;   $??
162,82,0,0q?6F   ???	#FF131313$ 0.698,0.615&?6q   $??33??6?   $	 0.4Q?6?   5K      5L      5M      ? 5N   
   $??
379,10,0,0q?6   $
??Left=?6#   $	??705??6>   
???????$??5??6]   $??5??6n   $	??219??6?   $	??Top=?6?   .+?5O      ?? $??19,10,447,110q?6   ???	#FF24CBC3$	??170??6C   $??68??6O   ._?5P      ? .+?5Q      ?? -   5        $	 qte??5Q       $??30(?6-   $??	10,0,0,10q?6;   
???????$??48??6a   $??Bottom=?6m   $	 0.7Q?6?   $??--??6?   $
??Left=?6?   $	??150??6?     5R      $ Package=?6/   $??61??6>   $??	109,0,0,0q?6I   
???????$ 0.698,0.615&?6o   $??68??6?   $	 0.6Q?6?   5S      5T      ?? 5U      $??226,10,240,110q?6   ???	#FFFFC758$	??170??6D   $??68??6P   ._?5V      ? .+?5W        $
 cart=?6/   $??61??6;   $??	109,0,0,0q?6F   
???????$ 0.698,0.615&?6l   $??68??6?   $	 0.6Q?6?   ?? 5X      -   5        $
 prod??5X       $??30(?6.   $??	10,0,0,10q?6<   
???????$??48??6b   $??Bottom=?6n   $	 0.7Q?6?   $??--??6?   $
??Left=?6?   $	??150??6?   5Y      5Z      ?? 5[      $??435,10,31,110q?6   ???	#FFF06A51$	??170??6C   $??68??6O   ._?5\      ? .+?5]        $ users=?6/   $??61??6<   $??	109,0,0,0q?6G   
???????$ 0.698,0.615&?6m   $??68??6?   $	 0.6Q?6?   ?? 5^      -   5        $ client??5^       $??30(?60   $??	10,0,0,10q?6>   
???????$??48??6d   $??Bottom=?6p   $	 0.7Q?6?   $??--??6?   $
??Left=?6?   $	??150??6?   5_      5`      ?? 5a      $??19,100,447,20q?6   ???	#FF2196F3$	??170??6C   $??68??6O   ._?5b      ? .+?5c        $ UserCardDetails=?6/   $??51??6F   $??	109,0,0,0q?6Q   
???????$ 0.698,0.615&?6w   $??68??6?   $	 0.6Q?6?   ?? 5d      -   5        $ 
emplyeesss??5d       $??30(?64   $??	10,0,0,10q?6B   
???????$??48??6h   $??Bottom=?6t   $	 0.7Q?6?   $??--??6?   $
??Left=?6?   $	??150??6?   5e      5f      ?? 5g      $??226,100,240,20q?6   ???	#FFA77EF0$	??170??6D   $??68??6P   ._?5h      ? .+?5i        $ Elevator=?6/   $??61??6?   $??	109,0,0,0q?6J   
???????$ 0.698,0.615&?6p   $??68??6?   $	 0.6Q?6?   ?? 5j      -   5        $ forniseurss??5j       $??30(?65   $??	10,0,0,10q?6C   
???????$??48??6i   $??Bottom=?6u   $	 0.7Q?6?   $??--??6?   $
??Left=?6?   $	??150??6?   5k      5l      ?? 5m      $??435,100,31,20q?6   ???	#FF6774C9$	??170??6C   $??68??6O   ._?5n      ? .+?5o        $
 Cash=?6/   $??61??6;   $??	109,0,0,0q?6F   
???????$ 0.698,0.615&?6l   $??68??6?   $	 0.6Q?6?   ?? 5p      -   5        $ 	salestout??5p       $??29(?63   $??	10,0,0,10q?6A   
???????$??48??6g   $??Bottom=?6s   $	 0.7Q?6?   $??--??6?   $
??Left=?6?   $??99??6?   5q      5r      5s      5t      5u      