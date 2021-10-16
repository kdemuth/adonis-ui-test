# AdonisUI Test project
.Net 5.0 WPF test project using AdonisUI and a DataGrid control.

## The Purpose

While evaluating AdonisUI for an upcoming project, I ran into an issue when rows are added directly to a DataGrid control.  This repo contains a bare bones test project derived from the evalution project to demonstrate the issue.

## The Issue

When AdonisUI visuals are enabled, and the DataGrid ItemSource property is not set, adding rows (items) directly to to the DataGrid throws an exception.  When AdonisUI is disabled rows are added as expected.  Not sure if this is caused by AdonisUI, or caused by somthing in (or missing from) my code.

## The Tests
Four scenarios can be tested with this source code as it currently exists. With AdonisUI disabled, the DataGrid can be updated directly or via a bound ObservableCollection.  With AdonisUI enabled, the DataGrid can only be updated via a bound ObservableCollection.

Configure the code per each test below, then build and run the Debug configuration.  Exceptions are caught in App.xaml.cs, and exception details are written to the Debug console.  I ran these tests with Visual Studio 2019 (version 16.11.5).

### Test 1 - AdonisUI enabled, rows added directly to DataGrid (ItemSource not set): Exception thrown
a. App.xaml: Uncomment AdonisUI resource dictionaries

	<ResourceDictionary>
	    <!-- -->
	    <ResourceDictionary.MergedDictionaries>
	        <ResourceDictionary Source="pack://application:,,,/AdonisUI;component/ColorSchemes/Dark.xaml"/>
	        <ResourceDictionary Source="pack://application:,,,/AdonisUI;component/ColorSchemes/Light.xaml"/>
	        <ResourceDictionary Source="pack://application:,,,/AdonisUI.ClassicTheme;component/Resources.xaml"/>
	    </ResourceDictionary.MergedDictionaries>
	    <!-- -->
	</ResourceDictionary>

b. MainWindow.xaml.cs: Set UseItemSource = false

	private const bool UseItemSource = false;

### Test 2 - AdonisUI disabled, rows added directly to DataGrid (ItemSource not set): Works as expected
a. App.xaml: Comment out AdonisUI resource dictionaries

	<ResourceDictionary>
	    <!--
	    <ResourceDictionary.MergedDictionaries>
	        <ResourceDictionary Source="pack://application:,,,/AdonisUI;component/ColorSchemes/Dark.xaml"/>
	        <ResourceDictionary Source="pack://application:,,,/AdonisUI;component/ColorSchemes/Light.xaml"/>
	        <ResourceDictionary Source="pack://application:,,,/AdonisUI.ClassicTheme;component/Resources.xaml"/>
	    </ResourceDictionary.MergedDictionaries>
	    -->
	</ResourceDictionary>

b. MainWindow.xaml.cs: Set UseItemSource = false

	private const bool UseItemSource = false;

### Test 3 - AdonisUI disabled, rows added to an ObservableCollection bound to the DataGrid: Works as expected
a. App.xaml: Comment out AdonisUI resource dictionaries

	<ResourceDictionary>
	    <!--
	    <ResourceDictionary.MergedDictionaries>
	        <ResourceDictionary Source="pack://application:,,,/AdonisUI;component/ColorSchemes/Dark.xaml"/>
	        <ResourceDictionary Source="pack://application:,,,/AdonisUI;component/ColorSchemes/Light.xaml"/>
	        <ResourceDictionary Source="pack://application:,,,/AdonisUI.ClassicTheme;component/Resources.xaml"/>
	    </ResourceDictionary.MergedDictionaries>
	    -->
	</ResourceDictionary>

b. MainWindow.xaml.cs: Set UseItemSource = true

	private const bool UseItemSource = true;

### Test 4 - AdonisUI enabled, rows added to an ObservableCollection bound to the DataGrid: Works as expected
a. App.xaml: Uncomment AdonisUI resource dictionaries

	<ResourceDictionary>
	    <!-- -->
	    <ResourceDictionary.MergedDictionaries>
	        <ResourceDictionary Source="pack://application:,,,/AdonisUI;component/ColorSchemes/Dark.xaml"/>
	        <ResourceDictionary Source="pack://application:,,,/AdonisUI;component/ColorSchemes/Light.xaml"/>
	        <ResourceDictionary Source="pack://application:,,,/AdonisUI.ClassicTheme;component/Resources.xaml"/>
	    </ResourceDictionary.MergedDictionaries>
	    <!-- -->
	</ResourceDictionary>

b. MainWindow.xaml.cs: Set UseItemSource = true

	private const bool UseItemSource = true;
