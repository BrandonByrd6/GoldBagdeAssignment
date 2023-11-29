# Insurance Claims
## Requirements

Komodo Insurance needs insurance claims to be processed in the order in which they are filed. Komodo allows an insurance claim to be made up to 30 days after an incident took place. If the claim is not in the proper time limit, it is not valid.

Repo Type: Queue

Each Claim will need (POCO): 

ClaimType (Car, Home, or Theft)
Description
ClaimAmount
DateOfIncident
DateOfClaim
IsValid (based on the date of the claim and the date of the incident)
The app will need to (repo methods): 

Add a new claim (C)
View the next claim (R)
See a list of all claims (R)
Process (remove) the next claim (D)


## Research on Queues
I know there First In, First Out

enqueue Items to add them to the Queue

dequeue Items to remove the from the Queue

Peak to the See the Next Item in the Queue