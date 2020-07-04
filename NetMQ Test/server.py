
import time
import zmq

# 绑定一个位置，client 与 server 需绑定相同位置
address = "tcp://127.0.0.1:5556"
ctx = zmq.Context()

# 使用 zmq.REP 模式，做为 server 端
rep = ctx.socket(zmq.REP)

rep.bind(address)
# 等待连线
time.sleep(1)
print("连接...")
while True:
    # 尝试接收从 client 端传来的消息
    message = rep.recv_string()
    print(message)

    if (message == "Hello"):
        rep.send_string('World')
        print('World')
        
    elif (message == "ni hao"):
        rep.send_string('World')
        print('Ni Hao')
    elif (message == "hi"):
        rep.send_string('World')
        print('Hi')
    else:
        rep.send_string('Nothing')

