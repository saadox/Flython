import requests as rq
from importlib.util import find_spec
import sys
__import__('os').system('pip install json') if find_spec('json') is None else print('Welcome si Jamal!\n')
import json

inf = '''\n
#################################
#   USES : GOOGLE API           #
#   GET AIROPORTS BY COUNTRY    #
#                               #
#   FB : fb.com/saadox.amrani   #
#   wtsp : +212612899034        #
# ###############################
\n'''

KEY     = 'AIzaSyCp33R6kdjt8Qptb34t9kUuBw2p2M41MSY' # private_ key
LINK    = lambda x:'https://maps.googleapis.com/maps/api/place/textsearch/json?query='+str(x)+'&key='+KEY+'&type=airport'

def ex__code(s):
    print(s)
    exit()


try:
    print(inf)
    DATA = []

    cntry   = sys.argv[1]
    resp    = rq.get(LINK(cntry)).content
    #print(resp)
    #json    = json.dumps(resp.decode('unicode_escape'))

    json    = json.loads(r''+resp.decode('utf-8')+'')
    status  = json['status']
    
    ex__code('ERROR : '+status) if status != 'OK' else print('SUCCESS!\n')

    token   = json['next_page_token']
    results = json['results']

    for aero in results:
        DATA.append({
            'name':aero['name'],
            'adress':aero['formatted_address'],
            'lat':str(aero['geometry']['location']['lat']),
            'lng':str(aero['geometry']['location']['lng']),
            'rating':str(aero['rating'])
        })

    with open(cntry+'.txt','wb') as f:
        for d,e in enumerate(DATA):
            f.write(bytes(str(d)+":"+str(e)+'\n',encoding='utf-8'))
        f.close()

except:
    raise