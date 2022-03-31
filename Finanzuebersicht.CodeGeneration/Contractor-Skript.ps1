########## Modules ##########

contractor add domain Accounting

########## Entities ##########

contractor add entity Accounting.AccountingEntry:AccountingEntries -s UserManagement.EmailUser:EmailUsers
contractor add entity Accounting.Category:Categories -s UserManagement.EmailUser:EmailUsers
contractor add entity Accounting.StartSaldo:StartSalden -s UserManagement.EmailUser:EmailUsers
contractor add entity Accounting.CategorySearchTerm:CategorySearchTerms -s UserManagement.EmailUser:EmailUsers

########## Relationen ##########

contractor add relation 1:n Accounting.Category:Categories Accounting.AccountingEntry:AccountingEntries
contractor add relation 1:n Accounting.Category:Categories Accounting.Category:Categories -n SuperCategory:ChildCategories
contractor add relation 1:n Accounting.Category:Categories Accounting.CategorySearchTerm:CategorySearchTerms

########## Properties ##########

contractor add property string:30 Auftragskonto -e Accounting.AccountingEntry:AccountingEntries
contractor add property DateTime Buchungsdatum -e Accounting.AccountingEntry:AccountingEntries
contractor add property DateTime ValutaDatum -e Accounting.AccountingEntry:AccountingEntries
contractor add property string:300 Buchungstext -e Accounting.AccountingEntry:AccountingEntries
contractor add property string:300 Verwendungszweck -e Accounting.AccountingEntry:AccountingEntries
contractor add property string:100 GlaeubigerId -e Accounting.AccountingEntry:AccountingEntries
contractor add property string:100 Mandatsreferenz -e Accounting.AccountingEntry:AccountingEntries
contractor add property string:100 Sammlerreferenz -e Accounting.AccountingEntry:AccountingEntries
contractor add property double LastschriftUrsprungsbetrag -e Accounting.AccountingEntry:AccountingEntries
contractor add property string:100 AuslagenersatzRuecklastschrift -e Accounting.AccountingEntry:AccountingEntries
contractor add property string:200 Beguenstigter -e Accounting.AccountingEntry:AccountingEntries
contractor add property string:22 IBAN -e Accounting.AccountingEntry:AccountingEntries
contractor add property string:15 BIC -e Accounting.AccountingEntry:AccountingEntries
contractor add property double Betrag -e Accounting.AccountingEntry:AccountingEntries
contractor add property string:10 Waehrung -e Accounting.AccountingEntry:AccountingEntries
contractor add property string:100 Info -e Accounting.AccountingEntry:AccountingEntries

contractor add property double Betrag -e Accounting.StartSaldo:StartSalden
contractor add property DateTime DatumAm -e Accounting.StartSaldo:StartSalden

contractor add property string:200 Title -e Accounting.Category:Categories
contractor add property string:30 Color -e Accounting.Category:Categories

contractor add property string:100 Term -e Accounting.CategorySearchTerm:CategorySearchTerms
