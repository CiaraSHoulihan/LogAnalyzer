# Assumptions
* Log data could be very large so went with ReadLines instead of ReadAllLines to reduce memory usage
* URLs can point to multiple web servers do did not include IPs in The top 3 most visited URLs
       - This can then mean the count isn't correct as some websites might have the same paths
*  Active IP addresses - this could either mean the most requests per IP address, or most successful requests, excluding server errors, per IP address

* Data does not change
* The first space will always be after the IP address
* There is no data before the IP address
* The URL lives inside the first quoted HTTP request part
