import yaml

def removeUnityTagAlias(filepath):
    """ removes unnecessary Unity tags and adds ID to node"""
    result = str()

    with open(filepath) as srcFile:
        for lineNumber,line in enumerate(srcFile.readlines()): 
            if line.startswith('--- !u!'):          
                result += '\n--- ' + line.split(' ')[2]   # remove the tag, but keep file ID
                result += '\nID: ' + line.split('&')[1]   # add file ID
            else:
                result += line

    return (result)


def loadYAML(filepath):
    """ loads nodes from YAML and appends to list """
    data = removeUnityTagAlias(filepath)
    nodes = list()

    for data in yaml.load_all(data):
        nodes.append(data)
    
    return (nodes)


def checkGameObjectName(nodes):
    objID = None
    for node in nodes:
        if 'GameObject' in node.keys() and 'm_Name' in node['GameObject'].keys() and node['GameObject']['m_Name'] == 'Coin':
            objID = node['ID']

    if objID == None:
        print("GameObject \'Coin\' not found")

    return(objID)

def checkTransform(nodes):
    """ checks Transform XYZ values """

    objID = checkGameObjectName(nodes)

    for node in nodes:
        if 'Transform' in node.keys() and 'm_GameObject' in node['Transform'].keys() and node['Transform']['m_GameObject']['fileID'] == objID:
            transform = node['Transform']
            if transform['m_LocalScale']['x'] == 1 and transform['m_LocalScale']['y'] == .05 and transform['m_LocalScale']['z'] == 0.8:
                print("Scale: OK")
            else:
                print("Scale: Wrong Value")
                print(transform['m_LocalScale'])

        if 'CapsuleCollider' in node.keys():
            if node['CapsuleCollider']['m_IsTrigger'] == 1:
                print("IsTrigger: OK")
            else:
                print("IsTrigger not checked")


if __name__ == "__main__":
    checkTransform(loadYAML('Assets/Prefabs/Coin.prefab'))