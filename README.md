# PointOfSaleTerminalApi
Implementation a point-of-sale scanning API that accepts an arbitrary ordering of products (similar to what would happen when actually at a checkout line) 
then returns the correct total price for an entire shopping cart based on the per unit prices or the volume prices as applicable.

Here are the products listed by code and the prices to use (there is no sales tax):

| Product Code  | Price |
| ------------- | ------------- |
| A  | $1.25 each or 3 for $3.00  |
| B  | $4.25  |
| C  | $1.00 or $5 for a six pack  |
| D  | $0.75  |

Regarding the above table the results of the point-of-sale scanning API:
| Scaned items  | Total price |
| ------------- | ------------- |
| ABCDABA  | $13.25  |
| CCCCCCC  | $6.00  |
| ABCD  | $7.25  |
