public float getProgress() {
    var prog = center.position.x - initialX;
    prog *= -1;
    
    return prog;
}

public float getReward() {
    var addReward = 0f;
    if (isTurned()) {
        addReward = -0.1f;
    }

    var change = getProgress() - lastProg;
    lastProg = getProgress();
    if (change < 0) change = 0;
    return change + addReward;
}

public bool isTurned() {
    var up = center.forward;
    var angle = Vector3.Angle(up, Vector3.up);
    return angle > 90;
}