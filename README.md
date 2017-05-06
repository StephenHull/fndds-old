# FNDDS
A utility to create and populate a database with the Food and Nutrient Database for
Dietary Studies (FNDDS) data from the United States Department of Agriculture (USDA) /
Agricultural Research Service (ARS) / Food Surveys Research Group (FSRG).

You can download the FNDDS data [here](https://www.ars.usda.gov/northeast-area/beltsville-md/beltsville-human-nutrition-research-center/food-surveys-research-group/docs/fndds/) as MS Access database files.

### Data fixes required to source files.

A few source files have invalid data that must be fixed before the data can be loaded into the SQL Server database. Below is a list of each file and the data that must be fixed.

1\. FNDDS 2001 - 2002
* For the SubcodeDesc table, update the [Subcode description] column to "Default Gram Weights" where Subcode equals zero (0).
* `UPDATE SubcodeDesc SET [Subcode description] = "Default Gram Weights" WHERE (Subcode = 0);`

2\. FNDDS 2003 - 2004
* For the SubcodeDesc table, update the [Subcode description] column to "Default Gram Weights" where Subcode equals zero (0).
* `UPDATE SubcodeDesc SET [Subcode description] = "Default Gram Weights" WHERE (Subcode = 0);`

3\. FNDDS 2005 - 2006

* For the SubcodeDesc table, update the [Subcode description] column to "Default Gram Weights" where Subcode equals zero (0).
* `UPDATE SubcodeDesc SET [Subcode description] = "Default Gram Weights" WHERE (Subcode = 0);`

4\. FNDDS 2011-2012

* For the AddFoodDescr table, update the [Additional food description] column in order to remove special characters.
* `UPDATE AddFoodDesc SET [Additional food description] = "Captain D's; Long John Silver;  Arthur Treacher's" WHERE ([Food code] = 26100200) AND ([Seq num] = 1);`
* `UPDATE AddFoodDesc SET [Additional food description] = "Papa John's Cinnapie" WHERE ([Food code] = 51160110) AND ([Seq num] = 5);`
* `UPDATE AddFoodDesc SET [Additional food description] = "Drake's Peanut Butter Creme Filled Devil's Food Cakes" WHERE ([Food code] = 53108200) AND ([Seq num] = 24);`
* `UPDATE AddFoodDesc SET [Additional food description] = "Little Debbie Creme-Filled Chocolate Cupcakes" WHERE ([Food code] = 53108200) AND ([Seq num] = 28);`
* `UPDATE AddFoodDesc SET [Additional food description] = "Little Debbie Boston Creme Roll" WHERE ([Food code] = 53109200) AND ([Seq num] = 20);`

5\. FNDDS 2013-2014

* For the MainFoodDesc table, update the [Main food description] column in order to remove special characters.
* `UPDATE MainFoodDesc SET [Main food description] = "Coffee, Iced Cafe Mocha, with non-dairy milk" WHERE ([Food code] = 92102602);`
* `UPDATE MainFoodDesc SET [Main food description] = "Coffee, Iced Cafe Mocha, decaffeinated, with non-dairy milk" WHERE ([Food code] = 92102612);`

* For the AddFoodDescr table, update the [Additional food description] column in order to remove special characters.
* `UPDATE AddFoodDesc SET [Additional food description] = "Captain D's; Long John Silver;  Arthur Treacher's" WHERE ([Food code] = 26100200) AND ([Seq num] = 1);`
* `UPDATE AddFoodDesc SET [Additional food description] = "Papa John's Cinnapie" WHERE ([Food code] = 51160110) AND ([Seq num] = 5);`
* `UPDATE AddFoodDesc SET [Additional food description] = "Drake's Peanut Butter Creme Filled Devil's Food Cakes" WHERE ([Food code] = 53108200) AND ([Seq num] = 24);`
* `UPDATE AddFoodDesc SET [Additional food description] = "Little Debbie Creme-Filled Chocolate Cupcakes" WHERE ([Food code] = 53108200) AND ([Seq num] = 28);`
* `UPDATE AddFoodDesc SET [Additional food description] = "Little Debbie Boston Creme Roll" WHERE ([Food code] = 53109200) AND ([Seq num] = 20);`
