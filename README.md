# FNDDS
A utility to create and populate a database with the Food and Nutrient Database for
Dietary Studies (FNDDS) data from the United States Department of Agriculture (USDA) /
Agricultural Research Service (ARS) / Food Surveys Research Group (FSRG).

You can download the FNDDS data [here](https://www.ars.usda.gov/northeast-area/beltsville-md/beltsville-human-nutrition-research-center/food-surveys-research-group/docs/fndds/) as MS Access database files.

### Data fixes required to source files.

A few source files have invalid data that must be fixed before the data can be loaded into the SQL Server database. Below is a list of each file and the data that must be fixed.

1\. FNDDS 2001 - 2002
* For the SubcodeDesc table, update the [Subcode description] column to "Default Gram Weights" where Subcode equals zero (0).
`UPDATE SubcodeDesc SET [Subcode description] = "Default Gram Weights" WHERE (Subcode = 0;`

2\. FNDDS 2003 - 2004
* For the SubcodeDesc table, update the [Subcode description] column to "Default Gram Weights" where Subcode equals zero (0).
`UPDATE SubcodeDesc SET [Subcode description] = "Default Gram Weights" WHERE (Subcode = 0;`

3\. FNDDS 2005 - 2006

* For the SubcodeDesc table, update the [Subcode description] column to "Default Gram Weights" where Subcode equals zero (0).
`UPDATE SubcodeDesc SET [Subcode description] = "Default Gram Weights" WHERE (Subcode = 0;`
