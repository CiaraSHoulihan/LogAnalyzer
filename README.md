# The task

The task is to parse a log file containing HTTP requests and to report on its contents.
For a given log file we want to know,

- The number of unique IP addresses
- The top 3 most visited URLs
- The top 3 most active IP addresses

## Example Data

177.71.128.21 - - [10/Jul/2018:22:21:28 +0200] "GET /intranet-analytics/ HTTP/1.1" 200 3574
A log file with test data is included with this assignment.

# Assumptions

- Log file is always readable
- Log file follows the standard Apache combined log format, with quoted request sections and space‑separated fields.
  `IP - - [date] "METHOD URL HTTP/version" status size`
- Active IP addresses could either mean the most requests per IP address, or most successful requests. Both were included.

# How To

- Run the application
- Enter the full path of the log file to parse said file
