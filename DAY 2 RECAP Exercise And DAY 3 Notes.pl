DAY 2 RECAP Exercise And DAY 3 Notes

Ex. Design and configure a call center for a sykesasia.com using 10.0.0.0/8 and 
having  1700 agnets, pc's, QA's.
C: 1700 is 11bits 
S: /32bits - /11bits = /21bits (3rd, 8i)
ipasok si 8i sa 3rd 
SykesAsia.com:10.0.8.0/21bits
1st: 10.0.8.1 /21bits + 1
Lastusable:10.0.15.254
Broadcast: 10.0.15.255 
NotSykesAsia.com: 10.0.16.0 /21 bits - 1

Configure terminal 
vlan 25
name: SykesAsia.com
int vlan 25
no shutdown
ip add 10.0.8.1 255.255.248.0
ip dhcp Excluded-Add 10.0.8.1 10.0.8.100
ip dhcp pool SykesAsia.com
    network 10.0.8.0 255.255.248.0
    default-router 10.0.8.1
    domain-name SykesAsia.com
    dns-server 10.41.1.0
    option 150 ip 10.41.100.8

-----------------------------------------------------------------------------

DAY 3

Task 1: Where are you in 4yrs?

Note: Ipv4 is slowly moving to Ipv6

"The world for future AI-Based Network Engineers.

-------------------------------------------------------------------------------

Exercise

1. 000a:000c:0000:0000:0000:0000:0000:0000 /64 
   Ans. a:c:: /64
2. 0000:0000:0000:0000:0000:0000:0000:0000 /0 
   Ans. ::/0 sanaAll: 0.0.0.0/0
3. fe80:0000:0000:0000:00aa:0000:0000:000f /64
   Ans. fe80::a:0:0:f/64
4. 2002:6500:0000:3000:0000:0000:0000:0000/64
   Ans. 2002:6500:0:300:: /64
5. 0000:0000:0000:0000:0000:0000:0000:0001 /128
   Ans. ::1
6. ff00:0000:0000:beef:a00a:0aa0:0000:0000 /8
   Ans

**to check the ipv6
>>>cmd 'route print'

-------------------------------------------------------------------------------

Task 2: Routing for world class network Engineer.

Requirements: 

CCNA: Static Route + OSPF 

Job: Local/Brand: Static, EIGRP,OSPF,B,VPN.

--------------------------------------------------------------------------------
D1,D2,R1,R2,R3,R4 Alias

config t
alias exec sc show run | section


-------------------------------------------------------------------------------

Task 3: 