'''
Credit:
https://scicomp.stackexchange.com/questions/20533/test-of-3rd-order-vs-4th-order-symplectic-integrator-with-strange-result
'''

import numpy as np
import matplotlib.pyplot as plt

def symplectic_integrate_step(qvt0, accel, dt, coeffs):
    q,v,t = qvt0
    for ai,bi in coeffs.T:
        v += bi * accel(q,v,t) * dt
        q += ai * v * dt
        t += ai * dt
    return q,v,t

def symplectic_integrate(qvt0, accel, t, coeffs):
    q = np.empty_like(t)
    v = np.empty_like(t)
    qvt = qvt0
    q[0] = qvt[0]
    v[0] = qvt[1]
    for i in range(1, len(t)):
        qvt = symplectic_integrate_step(qvt, accel, t[i]-t[i-1], coeffs)
        q[i] = qvt[0]
        v[i] = qvt[1]
    return q,v

c = np.pow(2.0, 1.0/3.0)
ruth4 = np.array([[0.5, 0.5*(1.0-c), 0.5*(1.0-c), 0.5],
                  [0.0,         1.0,          -c, 1.0]]) / (2.0 - c)

ruth3 = np.array([[2.0/3.0, -2.0/3.0, 1.0], [7.0/24.0, 0.75, -1.0/24.0]])
leap2 = np.array([[0.5, 0.5], [0.0, 1.0]])

accel = lambda q,v,t: -q
qvt0 = (1.0, 0.0, 0.0)
tmax = 2.0 * np.pi
N = 36

fig, ax = plt.subplots(1, figsize=(6, 6))
ax.axis([-1.3, 1.3, -1.3, 1.3])
ax.set_aspect('equal')
ax.set_title(r"Phase plot $(y(t),y'(t))$")
ax.grid(True)
t = np.linspace(0.0, tmax, 3*N+1)
q,v = symplectic_integrate(qvt0, accel, t, leap2)
ax.plot(q, v, label='leap2 (%d steps)' % (3*N), color='black')
t = np.linspace(0.0, tmax, N+1)
q,v = symplectic_integrate(qvt0, accel, t, ruth3)
ax.plot(q, v, label='ruth3 (%d steps)' % N, color='red')
q,v = symplectic_integrate(qvt0, accel, t, ruth4)
ax.plot(q, v, label='ruth4 (%d steps)' % N, color='blue')
ax.legend(loc='center')
fig.show()

plt.show()